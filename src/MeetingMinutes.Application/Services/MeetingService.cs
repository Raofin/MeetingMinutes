using MeetingMinutes.Application.Common;
using MeetingMinutes.Application.Interfaces;
using MeetingMinutes.Application.ViewModels;
using MeetingMinutes.Domain;
using MeetingMinutes.Domain.Entities;
using MeetingMinutes.Domain.Repositories;
using Serilog;

namespace MeetingMinutes.Application.Services;

internal class MeetingService(IMeetingRepository meetingRepository, IUnitOfWork unitOfWork, ILogger logger) : IMeetingService
{
    private readonly IMeetingRepository _meetingRepository = meetingRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ILogger _logger = logger;

    public async Task SaveMeetingAsync(MeetingViewModel model)
    {
        var meetingMinutesMaster = new MeetingMinutesMaster {
            Place = model.Place,
            ClientSide = model.ClientSide,
            HostSide = model.HostSide,
            Agenda = model.Agenda,
            Discussion = model.Discussion,
            Decision = model.Decision,
            Datetime = model.Datetime ?? null
        };


        if(model.CustomerType == CustomerType.Corporate)
        {
            meetingMinutesMaster.CorporateCustomerId = model.CustomerId;
        }
        else
        {
            meetingMinutesMaster.IndividualCustomerId = model.CustomerId;
        }

        try
        {
            using var transaction = _unitOfWork.BeginTransaction();

            var masterId = await _meetingRepository.SaveMeetingMinutesMasterAsync(meetingMinutesMaster);

            if (model.ProductServices != null && model.ProductServices.Count > 0)
            {
                var productServices = model.ProductServices.Select(MapToEntity).ToList();

                foreach (var productService in productServices)
                {
                    productService.MeetingMinutesId = masterId;
                    await _meetingRepository.SaveMeetingMinutesDetailAsync(productService);
                }
            }

            await _unitOfWork.CommitAsync();
            transaction.Commit();
        }
        catch (Exception ex)
        {
            _unitOfWork.Rollback();
            _logger.Error(ex, "Error occurred while saving meeting minutes");
            throw;
        }
    }

    private MeetingMinutesDetails MapToEntity(ProductServiceViewModel model)
    {
        return new MeetingMinutesDetails {
            ProductServiceId = model.ProductServiceId,
            Quantity = model.Quantity,
            Unit = model.Unit
        };
    }
}

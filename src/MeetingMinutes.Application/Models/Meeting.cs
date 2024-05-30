using MeetingMinutes.Application.Common;

namespace MeetingMinutes.Application.ViewModels;

public record MeetingViewModel(
    List<CustomerDDL> CustomerDDL,
    List<ProductServiceDDL> ProductServiceDDL,
    CustomerType? CustomerType = null,
    long? CustomerId = null,
    DateTime? Datetime = null,
    string? Place = null,
    string? ClientSide = null,
    string? HostSide = null,
    string? Agenda = null,
    string? Discussion = null,
    string? Decision = null,
    List<ProductServiceViewModel>? ProductServices = null
);
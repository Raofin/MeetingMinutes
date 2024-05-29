using ErrorOr;
using MeetingMinutes.Application.Common;
using MeetingMinutes.Application.Interfaces;
using MeetingMinutes.Application.ViewModels;
using MeetingMinutes.Domain.Repositories;
using Serilog;

namespace MeetingMinutes.Application.Services;

public class CustomerService(ICustomerRepository customerRepository, ILogger logger) : ICustomerService
{
    private readonly ICustomerRepository _customerRepository = customerRepository;
    private readonly ILogger _logger = logger;

    public async Task<List<CustomerViewModel>> GetCustomerAsync(CustomerType customerType)
    {

        if (customerType == CustomerType.Corporate)
        {
            var customers = await _customerRepository.GetCorporateAsync();

            return customers.Select(
                c => new CustomerViewModel(
                    CustomerId: c.CustomerId,
                    CustomerName: c.CustomerName
                )).ToList();
        }

        else if (customerType == CustomerType.Individual)
        {
            var customers = await _customerRepository.GetIndividualAsync();

            return customers.Select(
                c => new CustomerViewModel(
                    CustomerId: c.CustomerId,
                    CustomerName: c.CustomerName
                )).ToList();
        }
        else
        {
            _logger.Error("Invalid customer type");
            return [];
        }
    }

    public async Task<List<ProductServiceViewModel>> GetProductServiceAsync()
    {
        var productServices = await _customerRepository.GetProductsAsync();

        return productServices.Select(
            p => new ProductServiceViewModel(
                ProductServiceId: p.ProductServiceId,
                Name: p.Name,
                Type: p.Type
            )).ToList();
    }
}

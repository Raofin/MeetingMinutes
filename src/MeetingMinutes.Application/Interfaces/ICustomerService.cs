using MeetingMinutes.Application.Common;
using MeetingMinutes.Application.ViewModels;

namespace MeetingMinutes.Application.Interfaces;

public interface ICustomerService
{
    Task<List<CustomerDDL>> GetCustomerAsync(CustomerType customerType);
    Task<List<ProductServiceDDL>> GetProductServiceAsync();
}
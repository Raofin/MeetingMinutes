using MeetingMinutes.Application.Common;
using MeetingMinutes.Application.ViewModels;

namespace MeetingMinutes.Application.Interfaces;

public interface ICustomerService
{
    Task<List<CustomerViewModel>> GetCustomerAsync(CustomerType customerType);
    Task<List<ProductServiceViewModel>> GetProductServiceAsync();
}
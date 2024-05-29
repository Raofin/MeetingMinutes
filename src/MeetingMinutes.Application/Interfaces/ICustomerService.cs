using MeetingMinutes.Application.Common;
using MeetingMinutes.Application.ViewModels;

namespace MeetingMinutes.Application.Interfaces;

public interface ICustomerService
{
    Task<List<CustomerViewModel>> GetAsync(CustomerType customerType);
}
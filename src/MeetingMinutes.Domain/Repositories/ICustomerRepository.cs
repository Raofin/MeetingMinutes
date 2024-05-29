using MeetingMinutes.Domain.Entities;

namespace MeetingMinutes.Domain.Repositories;

public interface ICustomerRepository
{
    Task<List<CorporateCustomer>> GetCorporateAsync();
    Task<List<IndividualCustomer>> GetIndividualAsync();
}
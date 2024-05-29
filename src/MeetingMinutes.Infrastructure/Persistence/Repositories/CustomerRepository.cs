using MeetingMinutes.Domain.Entities;
using MeetingMinutes.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MeetingMinutes.Infrastructure.Persistence.Repositories;

public class CustomerRepository(AppDbContext context) : ICustomerRepository
{
    private readonly AppDbContext _dbContext = context;

    public async Task<List<CorporateCustomer>> GetCorporateAsync()
    {
        return await _dbContext.CorporateCustomers.ToListAsync();
    }

    public async Task<List<IndividualCustomer>> GetIndividualAsync()
    {
        return await _dbContext.IndividualCustomers.ToListAsync();
    }

    public async Task<List<ProductsService>> GetProductsAsync()
    {
        return await _dbContext.ProductsServices.ToListAsync();
    }
}

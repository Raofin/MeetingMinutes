using MeetingMinutes.Domain.Repositories;
using MeetingMinutes.Infrastructure.Persistence;
using MeetingMinutes.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MeetingMinutes.Infrastructure;

public static class Dependencies
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<ICustomerRepository, CustomerRepository>();

        return services;
    }
}

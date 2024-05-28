using MeetingMinutes.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace MeetingMinutes.Infrastructure;

public static class Dependencies
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }

}

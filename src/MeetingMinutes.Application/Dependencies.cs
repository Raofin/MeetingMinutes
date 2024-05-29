using MeetingMinutes.Application.Interfaces;
using MeetingMinutes.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MeetingMinutes.Application;

public static class Dependencies
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICustomerService, CustomerService>();

        return services;
    }
}

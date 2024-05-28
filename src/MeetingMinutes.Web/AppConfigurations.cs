using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using NUglify.Css;
using NUglify.JavaScript;
using Serilog;
using Serilog.Events;
using WebMarkupMin.AspNetCore8;
using FluentValidation;
using FluentValidation.AspNetCore;
using MeetingMinutes.Infrastructure;
using MeetingMinutes.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MeetingMinutes.Web;

public static class AppConfigurations
{
    public static IServiceCollection AddAppConfigurations(
        this IServiceCollection services, 
        IWebHostEnvironment environment, 
        IConfiguration configuration)
    {
        services
            .AddDatabase(configuration)
            .AddFluentValidator()
            .AddWebMarkupMin()
            .AddWebOptimizer(environment);

        return services;
    }

    #region ### Database ###

    private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
            connectionString,
            m => m.MigrationsHistoryTable("MigrationsHistory"))
        );

        return services;
    }

    public static void ApplyMigration(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var databaseCreator = dbContext.GetService<IRelationalDatabaseCreator>();

        if (!databaseCreator.Exists())
        {
            dbContext.Database.Migrate();
        }
    }

    #endregion

    #region ### Fluent Validator ###

    private static IServiceCollection AddFluentValidator(this IServiceCollection services)
    {
        return services
            .AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters()
            .AddValidatorsFromAssemblyContaining(typeof(Application.Dependencies));
    }

    #endregion


    #region ### WebMarkupMin & WebOptimizer ###

    private static IServiceCollection AddWebMarkupMin(this IServiceCollection services)
    {
        services
            .AddWebMarkupMin(
                options => {
                    options.AllowMinificationInDevelopmentEnvironment = false;
                    options.AllowCompressionInDevelopmentEnvironment = false;
                })
            .AddHtmlMinification(
                options => {
                    options.MinificationSettings.RemoveRedundantAttributes = true;
                    options.MinificationSettings.RemoveHttpProtocolFromAttributes = true;
                    options.MinificationSettings.RemoveHttpsProtocolFromAttributes = true;
                })
            .AddHttpCompression();

        return services;
    }

    private static IServiceCollection AddWebOptimizer(this IServiceCollection services, IHostEnvironment environment)
    {
        services.AddWebOptimizer(
            pipeline => {
                if (environment.IsDevelopment())
                {
                    pipeline.AddCssBundle("/css/bundle.css", CssSettings.Pretty(), "css/*.css");
                    pipeline.AddJavaScriptBundle("/js/bundle.js", CodeSettings.Pretty(), "js/*.js");
                }
                else
                {
                    pipeline.AddCssBundle("/css/bundle.css", "css/*.css");
                    pipeline.AddJavaScriptBundle("/js/bundle.js", "js/*.js");
                }
            },
            option => {
                option.EnableCaching = false;
                option.EnableDiskCache = false;
                option.EnableMemoryCache = false;
            }
        );

        return services;
    }

    #endregion

    #region ### Serilog ###

    public static IHostBuilder UseSerilogConfig(this IHostBuilder hostBuilder, IHostEnvironment env)
    {
        hostBuilder.UseSerilog((context, config) =>
            config.ReadFrom.Configuration(context.Configuration)
                .WriteTo.Console(env.IsDevelopment() ? LogEventLevel.Information : LogEventLevel.Error)
        );

        return hostBuilder;
    }

    #endregion
}

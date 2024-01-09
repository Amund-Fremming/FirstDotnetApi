using Microsoft.Extensions.DependencyInjection;
using Repositories;
using Services;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<CourseRepo>();
        // Add more repository registrations here
        return services;
    }

    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<CourseService>();
        // Add more service registrations here
        return services;
    }
}
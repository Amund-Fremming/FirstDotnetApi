using Microsoft.Extensions.DependencyInjection;
using Repositories;
using Services;
using Servies;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<CourseRepo>();
        services.AddScoped<StudentRepo>();
        return services;
    }

    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<CourseService>();
        services.AddScoped<StudentService>();
        return services;
    }
}
using backend.Repositories.PostRepository;
using backend.Services.PostService;

namespace backend.Helpers.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IPostRepository, PostRepository>();

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IPostService, PostService>();

        return services;
    }
}
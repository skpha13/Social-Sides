using backend.Helpers.Seeders;
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

    public static IServiceCollection AddSeeders(this IServiceCollection services)
    {
        services.AddTransient<CategorySeeder>();
        services.AddTransient<ProfileSeeder>();
        services.AddTransient<UserSeeder>();
        services.AddTransient<PostSeeder>();

        return services;
    }
}
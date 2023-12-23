using backend.Helpers.Seeders;
using backend.Models;
using backend.Repositories.PostRepository;
using backend.Repositories.UserRepository;
using backend.Services.PostService;
using backend.Services.UserService;
using Microsoft.AspNetCore.Identity;

namespace backend.Helpers.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IPostRepository, PostRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddScoped<UserManager<User>>();
        services.AddScoped<RoleManager<IdentityRole<Guid>>>();

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IPostService, PostService>();
        services.AddTransient<IUserService, UserService>();

        return services;
    }

    public static IServiceCollection AddSeeders(this IServiceCollection services)
    {
        services.AddTransient<CategorySeeder>();
        services.AddTransient<UserSeeder>();
        services.AddTransient<PostSeeder>();
        services.AddTransient<RoleSeeder>();
        services.AddTransient<UserSeeder>();
        services.AddTransient<UserRoleSeeder>();
        
        return services;
    }
}
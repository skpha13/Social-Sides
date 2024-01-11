using backend.Helpers.Seeders;
using backend.Models;
using backend.Repositories.CategoryRepository;
using backend.Repositories.JoinCategoryRepository;
using backend.Repositories.PostRepository;
using backend.Repositories.UserRepository;
using backend.Services;
using backend.Services.CategoryService;
using backend.Services.JoinCategoryService;
using backend.Services.PostActionService;
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
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<IJoinCategoryRepository, JoinCategoryRepository>();
        services.AddScoped<UserManager<User>>();
        services.AddScoped<RoleManager<IdentityRole<Guid>>>();

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IPostService, PostService>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<ICategoryService, CategoryService>();
        services.AddTransient<IPostActionService, PostActionService>();
        services.AddTransient<IJoinCategoryService, JoinCategoryService>();

        return services;
    }

    public static IServiceCollection AddSeeders(this IServiceCollection services)
    {
        services.AddTransient<CategorySeeder>();
        services.AddTransient<UserSeeder>();
        services.AddTransient<PostSeeder>();
        services.AddTransient<RoleSeeder>();
        services.AddTransient<UserRoleSeeder>();
        services.AddTransient<UserFollowsCategorySeeder>();
        
        return services;
    }
}
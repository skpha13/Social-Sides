using backend.Data;
using backend.Helpers.Extensions;
using backend.Helpers.Seeders;
using backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<DatabaseContext>(
	options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))	
);

builder.Services.AddIdentity<User, IdentityRole<Guid>>(opt => opt.SignIn.RequireConfirmedAccount = true)
	.AddRoles<IdentityRole<Guid>>()
	.AddEntityFrameworkStores<DatabaseContext>()
	.AddDefaultTokenProviders();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSeeders();

var app = builder.Build();
SeedData(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void SeedData(IHost app)
{
	var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
	using (var scope = scopedFactory.CreateScope())
	{
		var categoryService = scope.ServiceProvider.GetService<CategorySeeder>();
		categoryService.SeedInitialCategories();
		
		var roleService = scope.ServiceProvider.GetService<RoleSeeder>();
		roleService.SeedInitialRoles();
		
		var userService = scope.ServiceProvider.GetService<UserSeeder>();
		userService.SeedInitialUsers();
		
		var userRoleService = scope.ServiceProvider.GetService<UserRoleSeeder>();
		userRoleService.SeedInitialUsersRoles();
		
		var postService = scope.ServiceProvider.GetService<PostSeeder>();
		postService.SeedInitialPosts();
	}
}
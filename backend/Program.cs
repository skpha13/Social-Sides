using backend.Data;
using backend.Helpers.Extensions;
using backend.Helpers.Seeders;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<DatabaseContext>(
	options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))	
);
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
		var userService = scope.ServiceProvider.GetService<UserSeeder>();
		userService.SeedInitialUsers();
		var profileService = scope.ServiceProvider.GetService<ProfileSeeder>();
		profileService.SeedInitialProfiles();
		var postService = scope.ServiceProvider.GetService<PostSeeder>();
		postService.SeedInitialPosts();
	}
}
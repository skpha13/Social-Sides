using backend.Data;
using backend.Helpers.Extensions;
using backend.Helpers.Seeders;
using backend.Models;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
	options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
	{
		policy.WithOrigins("http://localhost:5173", "https://localhost:5173")
			.AllowAnyHeader()
			.AllowAnyMethod()
			.AllowCredentials();
	});
});

builder.Services.AddControllers();

builder.Services.AddDbContext<DatabaseContext>(
	options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))	
);

builder.Services.AddIdentity<User, IdentityRole<Guid>>()
	.AddRoles<IdentityRole<Guid>>()
	.AddEntityFrameworkStores<DatabaseContext>()
	.AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(opt =>
{
	opt.Password.RequireDigit = false;
	opt.Password.RequiredLength = 8;
	opt.User.RequireUniqueEmail = true;
	opt.SignIn.RequireConfirmedAccount = false;
	opt.SignIn.RequireConfirmedEmail = false;
	opt.SignIn.RequireConfirmedPhoneNumber = false;
	opt.SignIn.RequireConfirmedEmail = true;
});

FirebaseApp.Create(new AppOptions()
{
	Credential = GoogleCredential.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "social-sides-firebase-adminsdk-14ccb-375f894cd0.json"))
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddSeeders();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();
SeedData(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
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

		var userFollowCategoryService = scope.ServiceProvider.GetService<UserFollowsCategorySeeder>();
		userFollowCategoryService.SeedUserCategories();
	}
}
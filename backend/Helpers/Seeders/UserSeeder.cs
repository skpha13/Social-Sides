using backend.Data;
using backend.Models;
using BCryptNet = BCrypt.Net.BCrypt;

namespace backend.Helpers.Seeders;

public class UserSeeder
{
    private readonly DatabaseContext _dbContext;

    public UserSeeder(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void SeedInitialUsers()
    {
        if (!_dbContext.Users.Any())
        {
            var users = new List<User>
            {
                new User()
                {
                    Id = new Guid("439c82bf-f8cd-4300-a467-03a1f85a6d63"),
                    UserName = "skpha",
                    NormalizedUserName = "skpha".ToUpper(),
                    EmailConfirmed = true,
                    Email = "mal13adi03@gmail.com",
                    NormalizedEmail = "mal13adi03@gmail.com".ToUpper(),
                    PasswordHash = BCryptNet.HashPassword("parolaskpha")
                },
                new User()
                {
                    Id = new Guid("310a3aac-1bd8-43d5-ba39-d20f15a7b5b1"),
                    UserName = "Matoka26",
                    NormalizedUserName = "Matoka26".ToUpper(),
                    Email = "dogaru_mihail@gmail.com",
                    EmailConfirmed = true,
                    NormalizedEmail = "dogaru_mihail@gmail.com".ToUpper(),
                    PasswordHash = BCryptNet.HashPassword("parolamatoka26") 
                },
                new User()
                {
                    Id = new Guid("34b460b7-936a-4293-bde2-a835a99f2e52"),
                    UserName = "Qarty",
                    NormalizedUserName = "Qarty".ToUpper(),
                    Email = "mirceaandreirazvan@gmail.com",
                    EmailConfirmed = true,
                    NormalizedEmail = "mirceaandreirazvan@gmail.com".ToUpper(),
                    PasswordHash= BCryptNet.HashPassword("parolaqarty") 
                }
            };
            
            _dbContext.Users.AddRange(users);
            _dbContext.SaveChanges();
        }
    }
}
using backend.Data;
using backend.Models;

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
                    DateCreated = DateTime.Now,
                    LastModified = DateTime.Now,
                    Username = "skpha",
                    FirstName = "Adrian",
                    LastName = "Mincu",
                    Email = "mal13adi03@gmail.com",
                    Password = "parolaskpha"
                },
                new User()
                {
                    Id = new Guid("310a3aac-1bd8-43d5-ba39-d20f15a7b5b1"),
                    DateCreated = DateTime.Now,
                    LastModified = DateTime.Now,
                    Username = "Matoka26",
                    FirstName = "Mihai",
                    LastName = "Dogaru",
                    Email = "dogaru_mihail@gmail.com",
                    Password = "parolamatoka26"
                },
                new User()
                {
                    Id = new Guid("34b460b7-936a-4293-bde2-a835a99f2e52"),
                    DateCreated = DateTime.Now,
                    LastModified = DateTime.Now,
                    Username = "Qarty",
                    FirstName = "Razvan",
                    LastName = "Mircea",
                    Email = "mirceaandreirazvan@gmail.com",
                    Password = "parolaqarty"
                }
            };
            
            _dbContext.Users.AddRange(users);
            _dbContext.SaveChanges();
        }
    }
}
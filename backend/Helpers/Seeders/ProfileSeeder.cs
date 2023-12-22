using backend.Data;
using backend.Models;

namespace backend.Helpers.Seeders;

public class ProfileSeeder
{
    private readonly DatabaseContext _dbContext;

    public ProfileSeeder(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void SeedInitialProfiles()
    {
        if (!_dbContext.Profiles.Any())
        {
            var profiles = new List<Profile>
            {
                new Profile()
                {
                    Id = new Guid("9e062751-dde8-4d81-8c8d-ab15d19facc7"),
                    DateCreated = DateTime.Now,
                    LastModified = DateTime.Now,
                    username = "skpha",
                    UserId = new Guid("439c82bf-f8cd-4300-a467-03a1f85a6d63")
                },
                new Profile()
                {
                    Id = new Guid("fb69496c-2b98-4a5d-8d15-126278c4db15"),
                    DateCreated = DateTime.Now,
                    LastModified = DateTime.Now,
                    username = "Matoka26",
                    UserId = new Guid("310a3aac-1bd8-43d5-ba39-d20f15a7b5b1")
                },
                new Profile()
                {
                    Id = new Guid("b6daee6e-7485-4cdd-b9a7-3ca5c8617fd3"),
                    DateCreated = DateTime.Now,
                    LastModified = DateTime.Now,
                    username = "Qarty",
                    UserId = new Guid("34b460b7-936a-4293-bde2-a835a99f2e52")
                }
            };
            
            _dbContext.Profiles.AddRange(profiles);
            _dbContext.SaveChanges();
        }
    }
}
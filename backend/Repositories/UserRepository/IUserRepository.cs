using backend.Models;

namespace backend.Repositories.UserRepository;

public interface IUserRepository
{
     Task<User>? GetUserById(Guid id);
     Task CreateAsync(User user);
     Task Update(User user);
     Task Delete(Guid userId);
}
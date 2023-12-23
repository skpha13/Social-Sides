using backend.Models;
using Microsoft.AspNetCore.Identity;

namespace backend.Repositories.UserRepository;

public class UserRepository : IUserRepository
{
    private readonly UserManager<User> _userManager;

    public UserRepository(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<User>? GetUserById(Guid id)
    {
        return await _userManager.FindByIdAsync(id.ToString());
    }
    
    public async Task CreateAsync(User user)
    {
        var result = await _userManager.CreateAsync(user);
        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, "User");
            return;
        }

        throw new Exception(result.Errors.First().Description.ToString());
    }

    public async Task Update(User user)
    {
        if ((await _userManager.UpdateAsync(user)).Succeeded == false)
            throw new Exception("User update failed");
    }

    public async Task Delete(User user)
    {
        if ((await _userManager.DeleteAsync(user)).Succeeded == false)
            throw new Exception("User update failed");
    }
}
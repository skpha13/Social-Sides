using backend.Data;
using backend.Models;
using backend.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories.JoinCategoryRepository;

public class JoinCategoryRepository: IJoinCategoryRepository
{
    protected readonly DatabaseContext _dbContext;
    protected readonly DbSet<UserFollowsCategory> _table;

    public JoinCategoryRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
        _table = _dbContext.Set<UserFollowsCategory>();
    }

    public async Task CreateAsync(UserFollowsCategory entity)
    {
        await _table.AddAsync(entity);
    }
    
    public async Task<bool> SaveAsync()
    {
        return await _dbContext.SaveChangesAsync() > 0;
    }
}
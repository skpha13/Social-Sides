using backend.Data;
using backend.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories.GenericRepository;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly DatabaseContext _dbContext;
    protected readonly DbSet<TEntity> _table;

    public GenericRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
        _table = _dbContext.Set<TEntity>();
    }
    
    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _table.AsNoTracking().ToListAsync();
    }

    public async Task CreateAsync(TEntity entity)
    {
        await _table.AddAsync(entity);
    }

    public async Task CreateRangeAsync(IEnumerable<TEntity> entities)
    {
        await _table.AddRangeAsync(entities);
    }

    public void Update(TEntity entity)
    {
        _table.Update(entity);
    }

    public void UpdateRange(IEnumerable<TEntity> entities)
    {
        _table.UpdateRange(entities);
    }

    public void Delete(TEntity entity)
    {
        _table.Remove(entity);
    }

    public void DeleteRange(IEnumerable<TEntity> entities)
    {
        _table.RemoveRange(entities);
    }

    public async Task<TEntity?>? FindByIdAsync(Guid id)
    {
        return await _table.FindAsync(id);
    }

    public async Task<bool> SaveAsync()
    {
        return await _dbContext.SaveChangesAsync() > 0;
    }
}
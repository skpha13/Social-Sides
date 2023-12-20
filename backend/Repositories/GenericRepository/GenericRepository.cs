using backend.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories.GenericRepository;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly DbContext DbContext;
    protected readonly DbSet<TEntity> Table;

    public GenericRepository(DbContext dbContext)
    {
        DbContext = dbContext;
        Table = this.DbContext.Set<TEntity>();
    }
    
    public async Task<List<TEntity>> GetAllAsync()
    {
        return await Table.AsNoTracking().ToListAsync();
    }

    public async Task CreateAsync(TEntity entity)
    {
        await Table.AddAsync(entity);
    }

    public async Task CreateRangeAsync(IEnumerable<TEntity> entities)
    {
        await Table.AddRangeAsync(entities);
    }

    public void Update(TEntity entity)
    {
        Table.Update(entity);
    }

    public void UpdateRange(IEnumerable<TEntity> entities)
    {
        Table.UpdateRange(entities);
    }

    public void Delete(TEntity entity)
    {
        Table.Remove(entity);
    }

    public void DeleteRange(IEnumerable<TEntity> entities)
    {
        Table.RemoveRange(entities);
    }

    public async Task<TEntity?>? FindByIdAsync(Guid id)
    {
        return await Table.FindAsync(id);
    }

    public async Task<bool> SaveAsync()
    {
        return await DbContext.SaveChangesAsync() > 0;
    }
}
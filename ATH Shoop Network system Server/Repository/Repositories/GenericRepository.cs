using ATH_Shoop_Network_system_Server.Repository.Interfaces;

using Microsoft.EntityFrameworkCore;
using ATH_Shoop_Network_system_Server.Data;
using ATH_Shoop_Network_system_Server.Services;

namespace ATH_Shoop_Network_system_Server.Repository.Repositories;

public class GenericRepository<T> : IGenericRepository<T>
    where T : class, IEntity<int>
{
    protected ApplicationDbContext _context;
    protected DbSet<T> _dbSet;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }


    public virtual ServiceResult GetById(int id)
    {
        IQueryable<T> query = _dbSet.Where(id);
        return query;
    }

    public virtual async Task<T> Create(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<T> Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<T> Delete(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null)
        {
            return null;
        }
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<IEnumerable<T>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

}



using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace UserManager.DataAccess.Services.Repositories;
public class Repository<T> : IRepository<T> where T : class
{
    private readonly UserManagerContext _dbContext;
    private readonly DbSet<T> _dbSet;
    public Repository(UserManagerContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<T>();
    }

    public T Add(T entity)
    {
        _dbSet.Add(entity);

        return entity;
    }

    public void Delete(T entity) => _dbSet.Remove(entity);

    public IEnumerable<T> GetAll() => _dbSet.AsNoTracking().ToList();

    public T Update(T entity)
    {
        _dbSet.Entry(entity).State = EntityState.Modified;

        return entity;
    }

    public void SaveChanges() => _dbContext.SaveChanges();
}
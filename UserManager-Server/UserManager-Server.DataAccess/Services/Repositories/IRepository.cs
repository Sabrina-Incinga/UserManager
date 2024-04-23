using System.Collections.Generic;

namespace UserManager.DataAccess.Services.Repositories;
public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll();
    T Add(T entity);
    T Update(T entity);
    void Delete(T entity);
    void SaveChanges();
}

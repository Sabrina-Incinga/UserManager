using UserManager.DataAccess.Services.Repositories;

namespace UserManager.DataAccess.Services;
public interface IUMUnitOfWork
{
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
}

namespace UserManager.DataAccess.Services.Repositories.Factory;
public interface IRepositoryFactory
{
    IRepository<T> CreateRepository<T>() where T : class;
}
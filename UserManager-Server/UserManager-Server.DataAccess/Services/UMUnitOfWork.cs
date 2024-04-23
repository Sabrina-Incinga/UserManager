using System;
using System.Collections.Generic;
using UserManager.DataAccess.Services.Repositories;
using UserManager.DataAccess.Services.Repositories.Factory;

namespace UserManager.DataAccess.Services
{
    public class UMUnitOfWork : IUMUnitOfWork
    {
        private readonly IRepositoryFactory _repositoryFactory;
        private Dictionary<string, object> _repositories;

        public UMUnitOfWork(IRepositoryFactory repositoryFactory)
        {
            _repositories = new Dictionary<string, object>();
            _repositoryFactory = repositoryFactory;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories.TryGetValue(typeof(TEntity).FullName!, out var repository))
            {
                if (repository is IRepository<TEntity> repositoryCasted)
                    return repositoryCasted;
                throw new ArgumentException("Unable to retrieve repository");
            }

            var repositoryToReturn = _repositoryFactory.CreateRepository<TEntity>();
            _repositories.Add(typeof(TEntity).FullName!, repositoryToReturn);

            return repositoryToReturn;
        }
    }
}
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ACE.Shared.Factories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private IServiceProvider _provider;

        public RepositoryFactory(object iocContainer)
        {
            _provider = iocContainer as IServiceProvider;
        }
        T IRepositoryFactory.GetDataRepository<T>()
        {
            return _provider.GetService<T>();
        }
    }
}

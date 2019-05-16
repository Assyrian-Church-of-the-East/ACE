using ACE.Shared.Repositories;

namespace ACE.Shared.Factories
{
    public interface IRepositoryFactory
    {
        T GetDataRepository<T>() where T : IRepository;
    }
}

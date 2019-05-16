using ACE.Model;
using ACE.Shared.Repositories;
using System.Threading.Tasks;

namespace ACE.Repositories.Interfaces
{
    public interface IFamilyRepository : IRepository<Family>
    {
        Task<Family> GetByIdentity(string identity, bool checkLocal = false);
    }
}

using ACE.Model;
using ACE.Shared.Repositories;
using System.Threading.Tasks;

namespace ACE.Repositories.Interfaces
{
    public interface IMemberRepository : IRepository<Member>
    {
        Member ActivateMember(int memberId, bool deactivate);

        Task<Member> GetByRegistrationNumber(string registrationNumber, bool checkLocal = false);

    }
}

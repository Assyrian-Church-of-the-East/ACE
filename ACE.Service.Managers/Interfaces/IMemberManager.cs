using ACE.Model;

namespace ACE.Service.Managers.Interfaces
{
    public interface IMemberManager
    {
        Member ActivateMember(int memberId, bool activate);
    }
}

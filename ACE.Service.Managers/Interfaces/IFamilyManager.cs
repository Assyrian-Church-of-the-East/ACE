using ACE.Model;
using System.Collections.Generic;

namespace ACE.Service.Managers.Interfaces
{
    public interface IFamilyManager
    {
        IList<Member> GetFamilyMember();
    }
}

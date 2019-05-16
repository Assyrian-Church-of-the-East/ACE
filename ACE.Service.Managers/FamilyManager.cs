using ACE.Model;
using ACE.Repositories.Interfaces;
using ACE.Service.Managers.Interfaces;
using System;
using System.Collections.Generic;

namespace ACE.Service.Managers
{
    //TODO deletes later
    public class FamilyManager : ManagerBase<Family>, IFamilyManager
    {
        readonly IFamilyRepository _familyRepository;
        public FamilyManager(IFamilyRepository familyRepository) : base(familyRepository)
        {

        }

        public IList<Member> GetFamilyMember()
        {
            throw new NotImplementedException();
        }
    }
}

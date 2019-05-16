using ACE.Model;
using ACE.Repositories.Interfaces;
using ACE.Service.Managers.Interfaces;
using System;

namespace ACE.Service.Managers
{
    //TODO deletes later
    public class MemberManager : ManagerBase<Member>, IMemberManager
    {
        readonly IMemberRepository _memberRepository;
        public MemberManager(IMemberRepository memberRepository) : base(memberRepository)
        {

        }

        public Member ActivateMember(int memberId, bool activate)
        {
            return _memberRepository.ActivateMember(memberId, activate);
        }

    }
}

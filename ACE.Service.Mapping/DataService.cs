using ACE.Model;
using ACE.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ACE.Service.Mapping
{
    public class DataService : IDataService
    {
        private IMemberRepository _memberRepository;
        private IFamilyRepository _familyRepository;

        public DataService(IMemberRepository memberRepository, IFamilyRepository familyRepository)
        {
            _memberRepository = memberRepository;
            _familyRepository = familyRepository;
        }

        #region Family

        public Task<Family> GetByFamilyIdentity(string identity)
        {
            return _familyRepository.GetByIdentity(identity);
        }
        public Task<List<Family>> GetAllFamiliesAsync()
        {
            return _familyRepository.GetAllAsync();
        }

        #endregion Family

        #region memeber
        public Task<List<Member>> GetAllMembersAsync()
        {
            return _memberRepository.GetAllAsync();
        }

        public Task<Member> GetByRegistrationNumber(string registrationNumber)
        {
            return _memberRepository.GetByRegistrationNumber(registrationNumber);
        }

        public async Task CreateFamilyAsync(Family newFamily)
        {
            await _familyRepository.InsertAsync(newFamily);
        }

        public async Task CreateMemberAsync(Member newMember)
        {
            await _memberRepository.InsertAsync(newMember);
        }

        #endregion memeber
    }
}

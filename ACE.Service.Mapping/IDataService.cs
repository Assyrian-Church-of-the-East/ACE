using ACE.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ACE.Service.Mapping
{
    public interface IDataService
    {

        Task CreateFamilyAsync(Family newFamily);

        Task CreateMemberAsync(Member newMember);

        Task<List<Member>> GetAllMembersAsync();

        Task<List<Family>> GetAllFamiliesAsync();

        Task<Family> GetByFamilyIdentity(string identity);


    }
}

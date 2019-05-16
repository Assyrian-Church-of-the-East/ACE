using ACE.Database;
using ACE.Model;
using ACE.Repositories.Interfaces;
using ACE.Shared.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ACE.Repositories
{
    public class MemberRepository : RepositoryBase<Member, AceDbContext>, IMemberRepository
    {
        public MemberRepository(AceDbContext context) : base(context)
        {
        }

        public Member ActivateMember(int memberId, bool deactivate)
        {
            var member = GetById(memberId);
            member.IsActive = deactivate;
            if (member.IsActive)
            {
                member.ActiveDate = DateTime.Now;
            }
            return member;
        }

        public Task<Member> GetByRegistrationNumber(string registrationNumber, bool checkLocal)
        {
            Member member = null;
            if (checkLocal)
            {
                member = DbSet.Local.FirstOrDefault(f=>f.RegistrationNumber.Equals(registrationNumber,StringComparison.InvariantCultureIgnoreCase));
            }
            return (member != null) ?
               Task.FromResult(member) :
               DbSet.FirstOrDefaultAsync(f => f.RegistrationNumber.Equals(registrationNumber, StringComparison.InvariantCultureIgnoreCase));
        }

    }

}

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
    public class FamilyRepository : RepositoryBase<Family, AceDbContext>, IFamilyRepository
    {
        public FamilyRepository(AceDbContext context) : base(context)
        {
        }

        public Task<Family> GetByIdentity(string identity, bool checkLocal = false)
        {
            Family family = null;
            if (checkLocal)
            {
                family = DbSet.Local.FirstOrDefault(f => f.Identity.Equals(identity, StringComparison.InvariantCultureIgnoreCase));
            }

            return family != null ?
                Task.FromResult(family) :
                DbSet.FirstOrDefaultAsync(f => f.Identity.Equals(identity, StringComparison.InvariantCultureIgnoreCase));
        }
    }

}

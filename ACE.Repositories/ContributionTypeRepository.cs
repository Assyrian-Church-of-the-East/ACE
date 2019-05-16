using ACE.Database;
using ACE.Model;
using ACE.Repositories.Interfaces;
using ACE.Shared.Repositories;

namespace ACE.Repositories
{
    public class ContributionTypeRepository : RepositoryBase<ContributionType, AceDbContext>, IContributionTypeRepository
    {
        public ContributionTypeRepository(AceDbContext context) : base(context)
        {
        }
    }

}

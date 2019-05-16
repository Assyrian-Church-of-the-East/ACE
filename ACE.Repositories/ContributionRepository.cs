using ACE.Database;
using ACE.Model;
using ACE.Repositories.Interfaces;
using ACE.Shared.Repositories;

namespace ACE.Repositories
{
    public class ContributionRepository : RepositoryBase<Contribution, AceDbContext>, IContributionRepository
    {
        public ContributionRepository(AceDbContext context) : base(context)
        {
        }
    }


}

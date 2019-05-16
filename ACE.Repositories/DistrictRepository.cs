using ACE.Database;
using ACE.Model;
using ACE.Repositories.Interfaces;
using ACE.Shared.Repositories;

namespace ACE.Repositories
{
    public class DistrictRepository : RepositoryBase<District, AceDbContext>, IDistrictRepository
    {
        public DistrictRepository(AceDbContext context) : base(context)
        {
        }
    }
}

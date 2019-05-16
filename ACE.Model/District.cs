using ACE.Shared;

namespace ACE.Model
{
    public class District: ObjectBase
    {
        public int DistrictId { get; set; }

        public string Name { get; set; }

        public string RegionName { get; set; }
    }
}

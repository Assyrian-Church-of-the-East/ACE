using ACE.Shared;
using System;

namespace ACE.Model
{

    public class ContributionType : ObjectBase
    {
        public int ContributionTypeId { get; set; }

        public int Amount { get; set; }

        public string TypeName { get; set; }

        public string Description { get; set; }

        public bool IsMandatory { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public bool IsOnlyOnce { get; set; }

        public bool IsPrFamily { get; set; }
    }
}

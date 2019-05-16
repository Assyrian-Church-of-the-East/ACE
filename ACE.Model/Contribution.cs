using ACE.Shared;
using System;

namespace ACE.Model
{
    public class Contribution: ObjectBase
    {
        public int ContributionId { get; set; }

        public string Description { get; set; }

        public int Amount { get; set; }

        public DateTime CreatedDate { get; set; }

        public int? MemberId { get; set; }

        public virtual Member Member { get; set; }

        public int? FamilyId { get; set; }

        public virtual Family Family { get; set; }

        public int ContributionTypeId { get; set; }

        public virtual ContributionType ContributionType { get; set; }
    }
}

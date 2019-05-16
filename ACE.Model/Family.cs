using ACE.Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACE.Model
{
    public class Family : ObjectBase
    {
        [Key]
        public int FamilyId { get; set; }

        public string Identity { get; set; }

        public virtual List<Member> Members { get; set; } = new List<Member>();

        public virtual int MainFamilyId { get; set; }

        [ForeignKey("MainFamilyId")]
        public virtual MainFamily MainFamily { get; set; }
    }
}

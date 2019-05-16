using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ACE.Model
{
    public class MainFamily
    {
        [Key]
        public int MainFamilyId { get; set; }

        public string FamilyClan { get; set; }

        public string FamilyName { get; set; }

        public virtual List<Family> Families { get; set; }
    }
}

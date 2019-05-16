using ACE.Shared;
using ACE.Shared.Enumeration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACE.Model
{
    public class Member : ObjectBase
    {
        [Key]
        public int MemberId { get; set; }

        public string RegistrationNumber { get; set; }

        public string FullName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsMainFamilyPerson { get; set; }

        public MemberStatus MemberStatus { get; set; } = MemberStatus.NotDefined;

        public DateTime? BirthDate { get; set; }

        public string Email { get; set; }

        public string TelephoneNumber1 { get; set; }

        public string TelephoneNumber2 { get; set; }

        public int Cpr { get; set; }

        public bool IsActive { get; set; }

        public bool IsUnderAge { get; set; }

        public int? DistrictId { get; set; }

        public string Contry { get; set; }

        public bool IsMarried { get; set; }

        public bool IsMale { get; set; }

        public string Profession { get; set; }

        [Column(TypeName = "date")]
        public DateTime WeddingDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime BaptismalDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime ActiveDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime RegistrationDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime DeathDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime MovingDate { get; set; }

        [ForeignKey("Family")]
        public int? FamilyId { get; set; }

        public virtual Family Family { get; set; }

        public virtual District District { get; set; }

        public virtual List<Note> Notes { get; set; } 
    }
}

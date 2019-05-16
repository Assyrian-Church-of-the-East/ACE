using ACE.Shared.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACE.WebApi.ModelDto
{
    public class MemberDto
    {
        public int MemberId { get; set; }

        public string Identity { get; set; }

        public string FullName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsMainFamilyPerson { get; set; }

        public MemberStatus MemberStatus { get; set; }

        public DateTime? BirthDate { get; set; }

        public string Email { get; set; }

        public string TelephoneNumber1 { get; set; }

        public string TelephoneNumber2 { get; set; }

        public int Cpr { get; set; }

        public bool IsActive { get; set; }

        public DateTime ActiveDate { get; set; }

        public bool IsUnderAge { get; set; }

        public  FamilyDto Family { get; set; }

        public  DistrictDto District { get; set; }

        public string Contry { get; set; }
    }
}

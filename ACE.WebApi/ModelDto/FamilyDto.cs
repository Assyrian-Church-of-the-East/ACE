using System.Collections.Generic;

namespace ACE.WebApi.ModelDto
{
    public class FamilyDto
    {
        public int FamilyId { get; set; }

        public string FamilyName { get; set; }

        public List<MemberDto> Members { get; set; }
    }
}

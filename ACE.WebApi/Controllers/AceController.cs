using ACE.Service.Mapping;
using ACE.WebApi.ModelDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ACE.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AceController : ControllerBase
    {
        private IDataService _dataService;
        public AceController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpPost("members")]
        //public async Task<ActionResult> GetAllMembers()
        public ActionResult GetAllMembers()
        {
            var testMembers = new List<MemberDto>
            {
               new MemberDto
               {
                   MemberId=1,
                   FullName ="Hello  Wolrd",
                   FirstName="Hello",
                   LastName="World",
                   Email="hw@test.com"
               }
            };

            return StatusCode(StatusCodes.Status200OK, testMembers);
            //var memebers = await _dataService.GetAllMembersAsync();
            //return StatusCode(StatusCodes.Status200OK, memebers);
        }

        [HttpPost("getmembers")]
        public async Task<ActionResult> GetAllMembers([FromBody] FamilyDto familyDto)
        {
            var memebers = await _dataService.GetAllMembersAsync();
            return StatusCode(StatusCodes.Status200OK, memebers);
        }

        [HttpPost("getallfamilies")]
        public async Task<ActionResult> getallfamilies()
        {
            var families = await _dataService.GetAllFamiliesAsync();
            return StatusCode(StatusCodes.Status200OK, families);
        }

        [HttpPost("addfamily")]
        public async Task<ActionResult> Addfamily([FromBody] FamilyDto familyDto)
        {
            var families = await _dataService.GetAllFamiliesAsync();
            return StatusCode(StatusCodes.Status200OK, families);
        }

    }
}

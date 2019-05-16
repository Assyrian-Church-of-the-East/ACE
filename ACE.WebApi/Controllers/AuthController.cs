using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACE.Service.Mapping;
using ACE.WebApi.ModelDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ACE.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IDataService _dataService;
        public AuthController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginInfo loginInfo = null)
        {
            return StatusCode(StatusCodes.Status200OK, true);
        }

        [HttpGet("currentIdentity")]
        public ActionResult CurrentIdentity()
        {
            var currentUser = new MemberDto
            {
                MemberId = 1,
                FullName = "Hello  Wolrd",
                FirstName = "Hello",
                LastName = "World",
                Email = "hw@test.com"
            };
            return StatusCode(StatusCodes.Status200OK, currentUser);
        }
    }
}
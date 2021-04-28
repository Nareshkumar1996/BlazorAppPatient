using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Healthware.Server.Dto;
using Healthware.Server.Service;
using Microsoft.AspNetCore.Authorization;

namespace Healthware.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public LoginController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<string> Post([FromBody] AuthenticateDto authenticateDto)
        {
            var result = await _authenticationService.Authenticate(authenticateDto);

            if (result.Value.Token != null)
            {
                return result.Value.Token;
            }

            return "Login Failed";
        }

        [Authorize]
        [HttpPost("GetUsername")]
        public string Post()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            var userName = claim[0].Value;
            return "Welcome To:" + userName;
        }

        [Authorize]
        [HttpGet("GetValue")]
        public IEnumerable<string> Get()
        {
            return new string[] {"Value1", "Value2"};
        }
    }
}

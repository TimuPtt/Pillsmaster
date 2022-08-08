using Microsoft.AspNetCore.Mvc;

using Pillsmaster.Application.Common.Exceptions;
using Pillsmaster.Application.Interfaces;
using Pillsmaster.Application.ViewModels;
using Pillsmaster.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pillsmaster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;

        public AuthorizationController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }


        // GET api/<AuthorizationController>/login
        [HttpPost("login")]
        public async Task<ActionResult<string>> Get([FromBody] UserViewModel userVm, CancellationToken cancellationToken)
        {
            try
            {
                var token = await _authorizationService.Login(userVm, cancellationToken);
                return Ok(token);
            }
            catch (AuthorizationFailedException e)
            {
                return BadRequest($"Authorization failed: ({e.Message})");
            }
        }

        // POST api/<AuthorizationController>/register
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register([FromBody] UserViewModel userVm, CancellationToken cancellationToken)
        {
            var user = await _authorizationService.Register(userVm, cancellationToken);

            return Ok(user);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSEA.BL.Models.Auth;
using SSEA.BL.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace SSEA.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        // POST: api/auth/register
        [HttpPost("register")]
        [SwaggerOperation(OperationId = "RegisterUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AuthResponseModel>> RegisterAsync([FromBody] RegisterUserModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await authService.RegisterUserAsync(model);
            return Ok(result);
        }

        // POST: api/auth/login
        [HttpPost("login")]
        [SwaggerOperation(OperationId = "LoginUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AuthResponseModel>> LoginAsync([FromBody] LoginUserModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await authService.LoginUserAsync(model);
            return Ok(result);
        }
    }
}

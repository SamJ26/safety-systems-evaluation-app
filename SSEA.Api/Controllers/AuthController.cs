using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSEA.BL.Models.Auth;
using SSEA.BL.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSEA.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        // api/auth/register
        [HttpPost("register")]
        [SwaggerOperation(OperationId = "RegisterUser")]
        public async Task<AuthResponseModel> RegisterAsync([FromBody] RegisterUserModel model)
        {
            var result = await authService.RegisterUserAsync(model);
            return result;
        }

        // api/auth/login
        [HttpPost("login")]
        [SwaggerOperation(OperationId = "LoginUser")]
        public async Task<AuthResponseModel> LoginAsync([FromBody] LoginUserModel model)
        {
            var result = await authService.LoginUserAsync(model);
            return result;
        }
    }
}

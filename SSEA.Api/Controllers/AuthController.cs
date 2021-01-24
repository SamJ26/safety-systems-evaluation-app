using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SSEA.BL.Models.Auth;
using SSEA.BL.Services.Interfaces;

namespace SSEA.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        // api/auth/register
        [HttpPost("Register")]
        public async Task<AuthResponseModel> RegisterAsync([FromBody]RegisterUserModel model)
        {
            var result = await authService.RegisterUserAsync(model);
            return result;
        }

        // api/auth/login
        [HttpPost("Login")]
        public async Task<AuthResponseModel> LoginAsync([FromBody]LoginUserModel model)
        {
            var result = await authService.LoginUserAsync(model);
            return result;;
        }
    }
}

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
        public async Task<IActionResult> RegisterAsync([FromBody]RegisterUserModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Some properties are not valid!");    // Status code: 400

            var result = await authService.RegisterUserAsync(model);

            // Send verification email ?
            if (result.IsSuccess)
                return Ok(result);      // Status code: 200

            return BadRequest(result);      
        }

        // api/auth/login
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody]LoginUserModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Some properties are not valid!");    // Status code 400

            var result = await authService.LoginUserAsync(model);
            if (result.IsSuccess)
                return Ok(result);      // Status code: 200
            return BadRequest(result);
        }
    }
}

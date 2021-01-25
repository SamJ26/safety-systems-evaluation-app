using SSEA.BL.Models.Auth;
using SSEA.BL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SSEA.BL.Services.Implementations
{
    public class AuthService : IAuthService
    {
        public async Task<AuthResponseModel> LoginUserAsync(LoginUserModel model)
        {
            // TODO
            var result = new AuthResponseModel();
            return result;
        }

        public async Task<AuthResponseModel> RegisterUserAsync(RegisterUserModel model)
        {
            // TODO
            var result = new AuthResponseModel();
            return result;
        }
    }
}

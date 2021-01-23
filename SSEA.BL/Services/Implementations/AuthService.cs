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
        public Task<AuthResponseModel> LoginUserAsync(LoginUserModel model)
        {
            throw new NotImplementedException();
        }

        public Task<AuthResponseModel> RegisterUserAsync(RegisterUserModel model)
        {
            throw new NotImplementedException();
        }
    }
}

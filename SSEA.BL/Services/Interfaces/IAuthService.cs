using SSEA.BL.Models.Auth;
using System.Threading.Tasks;

namespace SSEA.BL.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseModel> RegisterUserAsync(RegisterUserModel model);
        Task<AuthResponseModel> LoginUserAsync(LoginUserModel model);
    }
}

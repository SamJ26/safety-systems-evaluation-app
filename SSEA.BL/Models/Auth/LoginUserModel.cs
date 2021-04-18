using System.ComponentModel.DataAnnotations;

namespace SSEA.BL.Models.Auth
{
    public class LoginUserModel
    {
        [StringLength(maximumLength: 50, MinimumLength = 1)]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(maximumLength: 50, MinimumLength = 5)]
        public string Password { get; set; }
    }
}

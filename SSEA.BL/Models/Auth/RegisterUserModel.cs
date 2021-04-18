using System.ComponentModel.DataAnnotations;

namespace SSEA.BL.Models.Auth
{
    public class RegisterUserModel
    {
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1)]
        public string LastName { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 5)]
        public string Password { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 5)]
        public string ConfirmPassword { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.Auth
{
    public class RegisterUserModel
    {
        [StringLength(maximumLength: 50, MinimumLength = 1)]
        public string FirstName { get; set; }

        [StringLength(maximumLength: 50, MinimumLength = 1)]
        public string LastName { get; set; }

        [StringLength(maximumLength: 50, MinimumLength = 1)]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(maximumLength: 50, MinimumLength = 5)]
        public string Password { get; set; }

        [StringLength(maximumLength: 50, MinimumLength = 5)]
        public string ConfirmPassword { get; set; }
    }
}

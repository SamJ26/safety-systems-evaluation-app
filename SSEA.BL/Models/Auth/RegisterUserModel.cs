using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.Auth
{
    public class RegisterUserModel
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        [MinLength(5)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        [MinLength(5)]
        public string ConfirmPassword { get; set; }
    }
}

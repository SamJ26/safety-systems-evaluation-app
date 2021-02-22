using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.DAL.Entities.Auth
{
    public class Role : IdentityRole<int>
    {
        public bool IsValid { get; set; }
    }
}

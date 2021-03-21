using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SSEA.Api.Extensions
{
    public static class ControllerBaseExtension
    {
        public static int GetUserIdFromHttpContext(this ControllerBase controllerBase)
        {
            var stringValue = controllerBase.HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            return Int32.Parse(stringValue);
        }
    }
}

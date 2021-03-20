using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.BL.Models.Auth
{
    public class AuthResponseModel
    {
        public string Token { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; }

        // TODO: remove ?
        public DateTime? ExpireDate { get; set; }
        public Dictionary<string, string> UserInfo { get; set; }
    }
}

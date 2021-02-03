﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.Client.BL.Models
{
    public class LocalUserInfo
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AccessToken { get; set; }
    }
}
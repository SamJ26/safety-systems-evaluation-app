﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.BL.Models
{
    public class CodeListModelBase : ModelBase
    {
        public int IdCreated { get; set; }
        public string DateTimeCreated { get; set; }
        public int? IdUpdated { get; set; }
        public string DateTimeUpdated { get; set; }
        public bool IsValid { get; set; }
    }
}

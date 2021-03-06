﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.BL.Models
{
    public abstract class ExtendedModelBase : ModelBase
    {
        public int IdCreated { get; set; }
        public string DateTimeCreated { get; set; }
        public string UserNameCreated { get; set; }
        public int? IdUpdated { get; set; }
        public string DateTimeUpdated { get; set; }
        public string UserNameUpdated { get; set; }
        public StateModel CurrentState { get; set; }
    }
}

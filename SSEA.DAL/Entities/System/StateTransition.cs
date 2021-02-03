﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.System
{
    [Table("SY_StateTransition")]
    public class StateTransition : EntityBase
    {
        [StringLength(200)]
        public string Note { get; set; }

        public bool Valid { get; set; }

        [ForeignKey("CurrentState_Id")]
        public State CurrentState { get; set; }

        [ForeignKey("NextState_Id")]
        public State NextState { get; set; }
    }
}

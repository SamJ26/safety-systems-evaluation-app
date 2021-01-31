﻿using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.JoinEntities
{
    [Table("SafetyFunctionSubsystem")]
    public class SafetyFunctionSubsystem : EntityBase
    {
        public int SafetyFunctionId { get; set; }
        public SafetyFunction SafetyFunction { get; set; }
        public int SubsystemId { get; set; }
        public Subsystem Subsystem { get; set; }
    }
}

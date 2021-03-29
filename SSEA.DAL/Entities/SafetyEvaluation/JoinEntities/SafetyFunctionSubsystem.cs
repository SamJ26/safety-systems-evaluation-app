using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.JoinEntities
{
    [Table("SafetyFunctionSubsystem")]
    public class SafetyFunctionSubsystem : EntityBase
    {
        public bool IsRemoved { get; set; } = false;

        [Column("SafetyFunction_Id")]
        public int SafetyFunctionId { get; set; }

        [Column("Subsystem_Id")]
        public int SubsystemId { get; set; }

        public SafetyFunction SafetyFunction { get; set; }
        public Subsystem Subsystem { get; set; }
    }
}

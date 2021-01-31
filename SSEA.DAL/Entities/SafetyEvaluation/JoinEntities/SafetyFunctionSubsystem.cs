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
        public int SafetyFunctionId { get; set; }
        public int SubsystemId { get; set; }

        [ForeignKey("SafetyFunction_Id")]
        public SafetyFunction SafetyFunction { get; set; }

        [ForeignKey("Subsystem_Id")]
        public Subsystem Subsystem { get; set; }
    }
}

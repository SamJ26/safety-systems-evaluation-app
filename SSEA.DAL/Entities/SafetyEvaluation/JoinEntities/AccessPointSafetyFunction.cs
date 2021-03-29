using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.JoinEntities
{
    [Table("AccessPointSafetyFunction")]
    public class AccessPointSafetyFunction : EntityBase
    {
        public bool IsRemoved { get; set; } = false;

        [Column("AccessPoint_Id")]
        public int AccessPointId { get; set; }

        [Column("SafetyFunction_Id")]
        public int SafetyFunctionId { get; set; }

        public AccessPoint AccessPoint { get; set; }
        public SafetyFunction SafetyFunction { get; set; }
    }
}

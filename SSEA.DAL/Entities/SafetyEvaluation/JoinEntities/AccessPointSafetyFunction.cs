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
        public int AccessPointId { get; set; }
        public int SafetyFunctionId { get; set; }

        [Column("AccessPoint_Id")]
        public AccessPoint AccessPoint { get; set; }

        [Column("SafetyFunction_Id")]
        public SafetyFunction SafetyFunction { get; set; }
    }
}

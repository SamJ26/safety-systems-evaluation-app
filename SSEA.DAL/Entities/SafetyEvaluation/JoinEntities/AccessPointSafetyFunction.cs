using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.JoinEntities
{
    [Table("AccessPointSafetyFunction")]
    public class AccessPointSafetyFunction : ExtendedEntityBase
    {
        public int AccessPointId { get; set; }
        public int SafetyFunctionId { get; set; }

        public AccessPoint AccessPoint { get; set; }
        public SafetyFunction SafetyFunction { get; set; }
    }
}

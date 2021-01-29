using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL_methodics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.MainEntities.PL_methodics
{
    public class SafetyFunction_PL : ExtendedEntityBase
    {
        [StringLength(250)]
        public string Description { get; set; }

        // public virtual TypeOfFunction TypeOfFunction { get; set; }
        // public virtual EvaluationMethod EvaluationMethod { get; set; }
        // public virtual PL PLr { get; set; }
        // public virtual PL PL_result { get; set; }
        // public virtual S S { get; set; }
        // public virtual F F { get; set; }
        // public virtual P P { get; set; }
        // public virtual ICollection<AccessPointSafetyFunction> AccessPoints { get; set; }
        // public virtual ICollection<SafetyFunctionSubsystem> Subsystems { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.MainEntities.SIL_methodics
{
    public class SafetyFunction_SIL : ExtendedEntityBase
    {
        [StringLength(250)]
        public string Description { get; set; }

        // public virtual TypeOfFunction TypeOfFunction { get; set; }
        // public virtual EvaluationMethod EvaluationMethod { get; set; }
        // public virtual PFHd SILCL { get; set; }
        // public virtual PFHd SIL_result { get; set; }
        // public virtual Se Se { get; set; }
        // public virtual Fr Fr { get; set; }
        // public virtual Pr Pr { get; set; }
        // public virtual Av Av { get; set; }
        // public virtual ICollection<AccessPointSafetyFunction> AccessPoints { get; set; }
        // public virtual ICollection<SafetyFunctionSubsystem> Subsystems { get; set; }
    }
}

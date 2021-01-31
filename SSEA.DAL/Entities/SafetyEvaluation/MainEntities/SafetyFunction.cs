using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL_methodics;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL_methodics;
using SSEA.DAL.Entities.SafetyEvaluation.JoinEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.MainEntities
{
    [Table("SafetyFunction")]
    public class SafetyFunction : ExtendedEntityBase
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public TypeOfFunction TypeOfFunction { get; set; }
        public EvaluationMethod EvaluationMethod { get; set; }

        public ICollection<AccessPointSafetyFunction> AccessPointSafetyFunctions { get; set; }
        public ICollection<SafetyFunctionSubsystem> SafetyFunctionSubsystems { get; set; }

        // Properties for PL methodics:
        public PL PLr { get; set; }
        public PL PL_result { get; set; }
        public S S { get; set; }
        public F F { get; set; }
        public P P { get; set; }

        // Properties for SIL methodics:
        public PFHd SILCL { get; set; }
        public PFHd SIL_result { get; set; }
        public Se Se { get; set; }
        public Fr Fr { get; set; }
        public Pr Pr { get; set; }
        public Av Av { get; set; }
    }
}

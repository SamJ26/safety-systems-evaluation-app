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

        [ForeignKey("TypeOfFunction_Id")]
        public TypeOfFunction TypeOfFunction { get; set; }

        [ForeignKey("EvaluationMethod_Id")]
        public EvaluationMethod EvaluationMethod { get; set; }

        public ICollection<AccessPointSafetyFunction> AccessPointSafetyFunctions { get; set; }
        public ICollection<SafetyFunctionSubsystem> SafetyFunctionSubsystems { get; set; }

        // Properties for PL methodics:

        [ForeignKey("PLr_Id")]
        public PL PLr { get; set; }

        [ForeignKey("PL_result_Id")]
        public PL PL_result { get; set; }

        [ForeignKey("S_Id")]
        public S S { get; set; }

        [ForeignKey("F_Id")]
        public F F { get; set; }

        [ForeignKey("P_Id")]
        public P P { get; set; }

        // Properties for SIL methodics:

        [ForeignKey("SILCL_Id")]
        public PFHd SILCL { get; set; }

        [ForeignKey("SIL_result_Id")]
        public PFHd SIL_result { get; set; }

        [ForeignKey("Se_Id")]
        public Se Se { get; set; }

        [ForeignKey("Fr_Id")]
        public Fr Fr { get; set; }

        [ForeignKey("Pr_Id")]
        public Pr Pr { get; set; }

        [ForeignKey("Av_Id")]
        public Av Av { get; set; }
    }
}

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

        [Column("TypeOfFunction_Id")]
        public TypeOfFunction TypeOfFunction { get; set; }

        [Column("EvaluationMethod_Id")]
        public EvaluationMethod EvaluationMethod { get; set; }

        public ICollection<AccessPointSafetyFunction> AccessPointSafetyFunctions { get; set; }
        public ICollection<SafetyFunctionSubsystem> SafetyFunctionSubsystems { get; set; }

        // Properties for PL methodics:

        [Column("PLr_Id")]
        public PL PLr { get; set; }

        [Column("PL_result_Id")]
        public PL PL_result { get; set; }

        [Column("S_Id")]
        public S S { get; set; }

        [Column("F_Id")]
        public F F { get; set; }

        [Column("P_Id")]
        public P P { get; set; }

        // Properties for SIL methodics:

        [Column("SILCL_Id")]
        public PFHd SILCL { get; set; }

        [Column("SIL_result_Id")]
        public PFHd SIL_result { get; set; }

        [Column("Se_Id")]
        public Se Se { get; set; }

        [Column("Fr_Id")]
        public Fr Fr { get; set; }

        [Column("Pr_Id")]
        public Pr Pr { get; set; }

        [Column("Av_Id")]
        public Av Av { get; set; }
    }
}

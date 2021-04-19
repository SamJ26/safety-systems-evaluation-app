using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL;
using SSEA.DAL.Entities.SafetyEvaluation.JoinEntities;
using SSEA.DAL.Entities.System;
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

        public bool UsedOnMachine { get; set; }

        [Column("TypeOfFunction_Id")]
        public int TypeOfFunctionId { get; set; }
        public TypeOfFunction TypeOfFunction { get; set; }

        [Column("EvaluationMethod_Id")]
        public int EvaluationMethodId { get; set; }
        public EvaluationMethod EvaluationMethod { get; set; }

        public ICollection<AccessPointSafetyFunction> AccessPointSafetyFunctions { get; set; }
        public ICollection<SafetyFunctionSubsystem> SafetyFunctionSubsystems { get; set; }

        // Properties for PL methodics:

        [Column("PLr_Id")]
        public int? PLrId { get; set; }
        public PerformanceLevel PLr { get; set; }

        [Column("PLresult_Id")]
        public int? PLresultId { get; set; }
        public PerformanceLevel PLresult { get; set; }

        [Column("S_Id")]
        public int? SId { get; set; }
        public S S { get; set; }

        [Column("F_Id")]
        public int? FId { get; set; }
        public F F { get; set; }

        [Column("P_Id")]
        public int? PId { get; set; }
        public P P { get; set; }

        // Properties for SIL methodics:

        [Column("SILCL_Id")]
        public int? SILCLId { get; set; }
        public PFHd SILCL { get; set; }

        [Column("SILresult_Id")]
        public int? SILresultId { get; set; }
        public PFHd SILresult { get; set; }

        [Column("Se_Id")]
        public int? SeId { get; set; }
        public Se Se { get; set; }

        [Column("Fr_Id")]
        public int? FrId { get; set; }
        public Fr Fr { get; set; }

        [Column("Pr_Id")]
        public int? PrId { get; set; }
        public Pr Pr { get; set; }

        [Column("Av_Id")]
        public int? AvId { get; set; }
        public Av Av { get; set; }
    }
}

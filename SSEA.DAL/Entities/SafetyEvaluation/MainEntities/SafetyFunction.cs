using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL;
using SSEA.DAL.Entities.SafetyEvaluation.JoinEntities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Column("RequiredPL_Id")]
        public int? RequiredPLId { get; set; }
        public PerformanceLevel RequiredPL { get; set; }

        [Column("ResultantPL_Id")]
        public int? ResultantPLId { get; set; }
        public PerformanceLevel ResultantPL { get; set; }

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

        public double CalculatedPFHd { get; set; }

        [Column("RequiredSIL_Id")]
        public int? RequiredSILId { get; set; }
        public PFHd RequiredSIL { get; set; }

        [Column("SILCL_Id")]
        public int? SILCLId { get; set; }
        public PFHd SILCL { get; set; }

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

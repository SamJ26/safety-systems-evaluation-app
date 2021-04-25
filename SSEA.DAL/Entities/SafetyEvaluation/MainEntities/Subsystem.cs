using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL;
using SSEA.DAL.Entities.SafetyEvaluation.JoinEntities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSEA.DAL.Entities.SafetyEvaluation.MainEntities
{
    [Table("Subsystem")]
    public class Subsystem : ExtendedEntityBase
    {
        [StringLength(250)]
        public string Description { get; set; }

        [Column("TypeOfSubsystem_Id")]
        public int TypeOfSubsystemId { get; set; }
        public TypeOfSubsystem TypeOfSubsystem { get; set; }

        [Column("OperationPrinciple_Id")]
        public int OperationPrincipleId { get; set; }
        public OperationPrinciple OperationPrinciple { get; set; }

        public ICollection<SafetyFunctionSubsystem> SafetyFunctionSubsystems { get; set; }
        public ICollection<Element> Elements { get; set; }
        public ICollection<SubsystemCCF> SubsystemCCFs { get; set; }

        // Properties for PL methodics:

        public bool ValidCCF { get; set; }

        [Column("Category_Id")]
        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        [Column("ResultantMTTFd_Id")]
        public int? ResultantMTTFdId { get; set; }
        public MTTFd ResultantMTTFd { get; set; }

        [Column("ResultantDC_Id")]
        public int? ResultantDCId { get; set; }
        public DC ResultantDC { get; set; }

        [Column("ResulantPL_Id")]
        public int? ResultantPLId { get; set; }
        public PerformanceLevel ResultantPL { get; set; }


        // Properties for SIL methodics:

        public double CFF { get; set; }
        public double T1 { get; set; }
        public double T2 { get; set; }
        public double HFT { get; set; }
        public short ResultantSFF { get; set; }
        public double CalculatedPFHd { get; set; }

        [Column("Architecture_Id")]
        public int? ArchitectureId { get; set; }
        public Architecture Architecture { get; set; }

        [Column("ResultantPFHd_Id")]
        public int? ResultantPFHdId { get; set; }
        public PFHd ResultantPFHd { get; set; }
    }
}

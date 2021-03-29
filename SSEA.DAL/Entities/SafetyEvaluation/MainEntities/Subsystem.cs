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
    [Table("Subsystem")]
    public class Subsystem : ExtendedEntityBase
    {
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

        [Column("MTTFdResult_Id")]
        public int? MTTFdResultId { get; set; }
        public MTTFd MTTFdResult { get; set; }

        [Column("DCresult_Id")]
        public int? DCresultId { get; set; }
        public DC DCresult { get; set; }

        [Column("PLresult_Id")]
        public int? PLresultId { get; set; }
        public PerformanceLevel PLresult { get; set; }


        // Properties for SIL methodics:

        public double? T1 { get; set; }
        public double? T2 { get; set; }
        public double? HFT { get; set; }
        public short SFFresult { get; set; }

        [Column("Architecture_Id")]
        public int? ArchitectureId { get; set; }
        public Architecture Architecture { get; set; }

        [Column("PFHdResult_Id")]
        public int? PFHdResultId { get; set; }
        public PFHd PFHdResult { get; set; }

        [Column("CFF_Id")]
        public int? CFFId { get; set; }
        public CFF CFF { get; set; }
    }
}

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
        [ForeignKey("TypeOfSubsystem_Id")]
        public TypeOfSubsystem TypeOfSubsystem { get; set; }

        public ICollection<SafetyFunctionSubsystem> SafetyFunctionSubsystems { get; set; }
        public ICollection<Element> Elements { get; set; }
        public ICollection<SubsystemCCF> SubsystemCCFs { get; set; }

        // Properties for PL methodics:
        public bool CCFvalid { get; set; }

        [ForeignKey("Category_Id")]
        public Category Category { get; set; }

        [ForeignKey("MTTFdResult_Id")]
        public MTTFd MTTFdResult { get; set; }

        [ForeignKey("DCresult_Id")]
        public DC DCresult { get; set; }

        [ForeignKey("PLresult_Id")]
        public PerformanceLevel PLresult { get; set; }


        // Properties for SIL methodics:
        public double? T1 { get; set; }
        public double? T2 { get; set; }
        public double? SFFresult { get; set; }

        [ForeignKey("Architecture_Id")]
        public Architecture Architecture { get; set; }

        [ForeignKey("HFT_Id")]
        public HFT HFT { get; set; }

        [ForeignKey("PFHdResult_Id")]
        public PFHd PFHdResult { get; set; }

        [ForeignKey("CFF_Id")]
        public CFF CFF { get; set; }
    }
}

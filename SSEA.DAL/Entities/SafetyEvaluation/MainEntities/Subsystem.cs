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

        [ForeignKey("CurrentState_Id")]
        public State CurrentState { get; set; }

        public ICollection<SafetyFunctionSubsystem> SafetyFunctionSubsystems { get; set; }
        public ICollection<Element> Elements { get; set; }
        public ICollection<SubsystemCCF> SubsystemCCFs { get; set; }

        // Properties for PL methodics:
        public bool CCF_valid { get; set; }

        [ForeignKey("Category_Id")]
        public Category Category { get; set; }

        [ForeignKey("MTTFd_result_Id")]
        public MTTFd MTTFd_result { get; set; }

        [ForeignKey("DC_result_Id")]
        public DC DC_result { get; set; }

        [ForeignKey("PL_result_Id")]
        public PerformanceLevel PL_result { get; set; }


        // Properties for SIL methodics:
        public double? T1 { get; set; }
        public double? T2 { get; set; }
        public double? SFF_result { get; set; }

        [ForeignKey("Architecture_Id")]
        public Architecture Architecture { get; set; }

        [ForeignKey("HFT_Id")]
        public HFT HFT { get; set; }

        [ForeignKey("PFHd_result_Id")]
        public PFHd PFHd_result { get; set; }

        [ForeignKey("CFF_Id")]
        public CFF CFF { get; set; }
    }
}

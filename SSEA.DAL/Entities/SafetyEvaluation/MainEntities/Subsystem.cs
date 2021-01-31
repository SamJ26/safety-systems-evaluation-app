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
    [Table("Subsystem")]
    public class Subsystem : ExtendedEntityBase
    {
        [StringLength(50)]
        public string CatalogNumber { get; set; }

        public TypeOfSubsystem TypeOfSubsystem { get; set; } 

        public ICollection<SafetyFunctionSubsystem> SafetyFunctionSubsystems { get; set; }
        public ICollection<Element> Elements { get; set; }
        public ICollection<SubsystemCCF> SubsystemCCFs { get; set; }

        // Properties for PL methodics:
        public Category Category { get; set; }
        public MTTFd MTTFd_result { get; set; }
        public DC DC_result { get; set; }
        public PL PL_result { get; set; }
        public bool CCF_valid { get; set; }

        // Properties for SIL methodics:
        public double? T1 { get; set; }
        public double? T2 { get; set; }
        public double? SFF_result { get; set; }
        public Architecture Architecture { get; set; }
        public HFT HFT { get; set; }
        public PFHd PFHd_result { get; set; }
        public CFF CFF { get; set; }
    }
}

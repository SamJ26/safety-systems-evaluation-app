using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.MainEntities
{
    public class Subsystem : ExtendedEntityBase
    {
        [StringLength(50)]
        public string CatalogNumber { get; set; }

        // public TypeOfSubsystem TypeOfSubsystem { get; set; }
        // public Producer Producer { get; set; }
        // public ICollection<Element> Elements { get; set; }
        // public ICollection<SafetyFunctionSubsystem> SafetyFunctions { get; set; }
        // public ICollection<CCF> CCFs { get; set; }

        // Properties for PL methodics:
        // public Category Category { get; set; }
        // public MTTFd MTTFd_result { get; set; }
        // public DC DC_result { get; set; }
        // public PL PL_result { get; set; }
        // public bool CCF_valid { get; set; }

        // Properties for SIL methodics:
        public double? T1 { get; set; }
        public double? T2 { get; set; }
        public double? SFF_result { get; set; }

        // public Architecture Category { get; set; }
        // public HFT HFT { get; set; }
        // public PFHd PFHd_result { get; set; }
        // public CFF CFF { get; set; }
    }
}

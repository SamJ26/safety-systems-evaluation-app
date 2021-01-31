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

        [Column("TypeOfSubsystem_Id")]
        public TypeOfSubsystem TypeOfSubsystem { get; set; } 

        public ICollection<SafetyFunctionSubsystem> SafetyFunctionSubsystems { get; set; }
        public ICollection<Element> Elements { get; set; }
        public ICollection<SubsystemCCF> SubsystemCCFs { get; set; }

        // Properties for PL methodics:
        public bool CCF_valid { get; set; }

        [Column("Category_Id")]
        public Category Category { get; set; }

        [Column("MTTFd_result_Id")]
        public MTTFd MTTFd_result { get; set; }

        [Column("DC_result_Id")]
        public DC DC_result { get; set; }

        [Column("PL_result_Id")]
        public PL PL_result { get; set; }


        // Properties for SIL methodics:
        public double? T1 { get; set; }
        public double? T2 { get; set; }
        public double? SFF_result { get; set; }

        [Column("Architecture_Id")]
        public Architecture Architecture { get; set; }

        [Column("HFT_Id")]
        public HFT HFT { get; set; }

        [Column("PFHd_result_Id")]
        public PFHd PFHd_result { get; set; }

        [Column("CFF_Id")]
        public CFF CFF { get; set; }
    }
}

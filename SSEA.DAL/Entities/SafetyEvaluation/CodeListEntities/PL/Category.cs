﻿using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL
{
    [Table("Category")]
    public class Category : CodeListEntityBase
    {
        [Required]
        [StringLength(2)]
        public string Label { get; set; }

        [StringLength(250)]
        public string DescriptionCZ { get; set; }

        [StringLength(250)]
        public string DescriptionEN { get; set; }

        [StringLength(250)]
        public string RequirementsCZ { get; set; }

        [StringLength(250)]
        public string RequirementsEN { get; set; }

        [StringLength(250)]
        public string FailureBehaviorCZ { get; set; }

        [StringLength(250)]
        public string FailureBehaviorEN { get; set; }

        public bool Logic { get; set; }
        public bool RelevantCCF { get; set; }
        public short Channels { get; set; }
        public short CompareValue { get; set; }

        [Column("MinMTTFd_Id")]
        public int MinMTTFdId { get; set; }
        public MTTFd MinMTTFd { get; set; }

        [Column("MaxMTTFd_Id")]
        public int MaxMTTFdId { get; set; }
        public MTTFd MaxMTTFd { get; set; }

        [Column("MinDC_Id")]
        public int MinDCId { get; set; }
        public DC MinDC { get; set; }

        [Column("MaxDC_Id")]
        public int MaxDCId { get; set; }
        public DC MaxDC { get; set; }
    }
}

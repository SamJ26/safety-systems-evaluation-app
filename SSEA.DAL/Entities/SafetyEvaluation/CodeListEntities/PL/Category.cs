using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
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
        public string Description { get; set; }

        [StringLength(250)]
        public string Requirements { get; set; }

        [StringLength(250)]
        public string FailureBehavior { get; set; }

        public bool Logic { get; set; }
        public short Channels { get; set; }
        public bool RelevantCCF { get; set; }

        [ForeignKey("MinMTTFd_Id")]
        public MTTFd MinMTTFd { get; set; }

        [ForeignKey("MaxMTTFd_Id")]
        public MTTFd MaxMTTFd { get; set; }

        [ForeignKey("MinDC_Id")]
        public DC MinDC { get; set; }

        [ForeignKey("MaxDC_Id")]
        public DC MaxDC { get; set; }

        public ICollection<Subsystem> Subsystems { get; set; }
        public ICollection<TypeOfLogic> TypeOfLogics { get; set; }
    }
}

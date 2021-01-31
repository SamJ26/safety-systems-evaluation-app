using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL_methodics
{
    [Table("Category")]
    public class Category : EntityBase
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
        public bool CCF_relevant { get; set; }

        [Column("MTTFd_min_Id")]
        public MTTFd MTTFd_min { get; set; }

        [Column("MTTFd_max_Id")]
        public MTTFd MTTFd_max { get; set; }

        [Column("DC_min_Id")]
        public DC DC_min { get; set; }

        [Column("DC_max_Id")]
        public DC DC_max { get; set; }

        public ICollection<Subsystem> Subsystems { get; set; }
        public ICollection<TypeOfLogic> TypeOfLogics { get; set; }
    }
}

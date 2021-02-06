using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL
{
    [Table("MTTFd")]
    public class MTTFd : EntityBase
    {
        [Required]
        [StringLength(10)]
        public string Value { get; set; }

        public short Min { get; set; }
        public short Max { get; set; }

        public ICollection<Subsystem> Subsystems { get; set; }
        public ICollection<Element> Elements { get; set; }
        public ICollection<Category> Categories_MTTFd_min { get; set; }
        public ICollection<Category> Categories_MTTFd_max { get; set; }
    }
}

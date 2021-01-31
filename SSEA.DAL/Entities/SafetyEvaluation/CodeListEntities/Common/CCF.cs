using SSEA.DAL.Entities.SafetyEvaluation.JoinEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common
{
    public class CCF : EntityBase
    {
        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        public uint Points { get; set; }
        public bool ForPL { get; set; }

        public ICollection<SubsystemCCF> SubsystemCCFs { get; set; }
    }
}

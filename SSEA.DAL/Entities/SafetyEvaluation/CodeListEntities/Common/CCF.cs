using SSEA.DAL.Entities.SafetyEvaluation.JoinEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common
{
    [Table("CCF")]
    public class CCF : CodeListEntityBase
    {
        [Required]
        [StringLength(200)]
        public string DescriptionCZ { get; set; }

        [StringLength(200)]
        public string DescriptionEN { get; set; }

        [Required]
        [StringLength(50)]
        public string TypeCZ { get; set; }

        [StringLength(50)]
        public string TypeEN { get; set; }

        public uint Points { get; set; }
        public bool ForPL { get; set; }

        public ICollection<SubsystemCCF> SubsystemCCFs { get; set; }
    }
}

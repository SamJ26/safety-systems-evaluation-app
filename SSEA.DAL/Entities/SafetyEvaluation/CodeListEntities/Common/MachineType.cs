using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common
{
    [Table("MachineType")]
    public class MachineType : CodeListEntityBase
    {
        [Required]
        [StringLength(50)]
        public string NameCZ { get; set; }

        [StringLength(50)]
        public string NameEN { get; set; }

        [Required]
        [StringLength(200)]
        public string DescriptionCZ { get; set; }

        [StringLength(200)]
        public string DescriptionEN { get; set; }
    }
}

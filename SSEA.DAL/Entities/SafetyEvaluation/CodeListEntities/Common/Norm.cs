using SSEA.DAL.Entities.SafetyEvaluation.JoinEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common
{
    [Table("Norm")]
    public class Norm : CodeListEntityBase
    {
        [Required]
        [StringLength(40)]
        public string Label { get; set; }

        [Required]
        [StringLength(250)]
        public string NameCZ { get; set; }

        [StringLength(250)]
        public string NameEN { get; set; }

        [Required]
        [StringLength(20)]
        public string CatalogNumber { get; set; }

        [Required]
        [StringLength(2)]
        public string NormCategory { get; set; }

        public ICollection<MachineNorm> MachineNorms { get; set; }
    }
}

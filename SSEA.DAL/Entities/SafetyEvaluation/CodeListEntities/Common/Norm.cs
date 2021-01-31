using SSEA.DAL.Entities.SafetyEvaluation.JoinEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common
{
    [Table("Norm")]
    public class Norm : EntityBase
    {
        [Required]
        [StringLength(30)]
        public string Label { get; set; }

        [Required]
        [StringLength(250)]
        public string NameCZ { get; set; }

        [Required]
        [StringLength(250)]
        public string NameEN { get; set; }

        [Required]
        [StringLength(10)]
        public string CatalogNumber { get; set; }

        [Required]
        [StringLength(2)]
        public string NormCategory { get; set; }

        public ICollection<MachineNorm> MachineNorms { get; set; }
    }
}

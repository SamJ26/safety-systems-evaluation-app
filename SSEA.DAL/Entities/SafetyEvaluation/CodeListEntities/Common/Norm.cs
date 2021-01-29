using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common
{
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
        public char NormCategory { get; set; }
    }
}

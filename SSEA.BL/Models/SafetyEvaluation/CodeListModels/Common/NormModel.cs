using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common
{
    public class NormModel : ModelBase
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
    }
}

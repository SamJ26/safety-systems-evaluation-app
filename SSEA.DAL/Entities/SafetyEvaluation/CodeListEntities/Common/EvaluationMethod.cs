using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common
{
    [Table("EvaluationMethod")]
    public class EvaluationMethod : CodeListEntityBase
    {
        [Required]
        [StringLength(50)]
        public string NameCZ { get; set; }

        [StringLength(50)]
        public string NameEN { get; set; }

        [Required]
        [StringLength(3)]
        public string Shortcut { get; set; }
    }
}

using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL
{
    [Table("PL")]
    public class PerformanceLevel : CodeListEntityBase
    {
        [Required]
        [StringLength(2)]
        public string Label { get; set; }

        public short CompareValue { get; set; }
    }
}

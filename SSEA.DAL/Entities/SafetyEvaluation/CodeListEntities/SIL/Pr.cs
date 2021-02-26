using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL
{
    [Table("Pr")]
    public class Pr : CodeListEntityBase
    {
        [Required]
        [StringLength(50)]
        public string DescriptionCZ { get; set; }

        [StringLength(50)]
        public string DescriptionEN { get; set; }

        public short Value { get; set; }
    }
}

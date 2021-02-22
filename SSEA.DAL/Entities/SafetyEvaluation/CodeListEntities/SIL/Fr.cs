using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL
{
    [Table("Fr")]
    public class Fr : CodeListEntityBase
    {
        [Required]
        [StringLength(50)]
        public string FrequencyOfThreatCZ { get; set; }

        [StringLength(50)]
        public string FrequencyOfThreatEN { get; set; }

        public short Value { get; set; }

        public ICollection<SafetyFunction> SafetyFunctions { get; set; }
    }
}

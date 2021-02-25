using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common
{
    [Table("TypeOfFunction")]
    public class TypeOfFunction : CodeListEntityBase
    {
        [Required]
        [StringLength(100)]
        public string NameCZ { get; set; }

        [StringLength(100)]
        public string NameEN { get; set; }

        [StringLength(250)]
        public string DescriptionCZ { get; set; }

        [StringLength(250)]
        public string DescriptionEN { get; set; }
    }
}

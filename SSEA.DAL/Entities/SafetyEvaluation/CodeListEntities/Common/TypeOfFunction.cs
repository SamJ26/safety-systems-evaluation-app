using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common
{
    [Table("TypeOfFunction")]
    public class TypeOfFunction : EntityBase
    {
        [Required]
        [StringLength(50)]
        public string ShortName { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        public ICollection<SafetyFunction> SafetyFunctions { get; set; }
    }
}

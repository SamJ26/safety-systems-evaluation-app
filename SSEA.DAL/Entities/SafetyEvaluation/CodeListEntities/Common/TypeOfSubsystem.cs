using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common
{
    [Table("TypeOfSubsystem")]
    public class TypeOfSubsystem : CodeListEntityBase
    {
        [Required]
        [StringLength(20)]
        public string NameCZ { get; set; }

        [StringLength(20)]
        public string NameEN { get; set; }
    }
}

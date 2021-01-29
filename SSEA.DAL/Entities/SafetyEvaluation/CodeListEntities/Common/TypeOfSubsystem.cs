using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common
{
    public class TypeOfSubsystem : EntityBase
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
    }
}

using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common
{
    [Table("TypeOfSubsystem")]
    public class TypeOfSubsystem : EntityBase
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public ICollection<Subsystem> Subsystems { get; set; }
    }
}

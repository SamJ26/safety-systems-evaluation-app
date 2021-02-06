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
    public class PerformanceLevel : EntityBase
    {
        [Required]
        [StringLength(2)]
        public string Label { get; set; }

        public ICollection<SafetyFunction> SafetyFunctions_PLr { get; set; }
        public ICollection<SafetyFunction> SafetyFunctions_PL_result { get; set; }
        public ICollection<Subsystem> Subsystems { get; set; }
        public ICollection<TypeOfLogic> TypeOfLogics { get; set; }
    }
}

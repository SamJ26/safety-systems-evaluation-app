using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL_methodics
{
    public class PFHd : EntityBase
    {
        [Required]
        [StringLength(20)]
        public short Label { get; set; }

        [Required]
        public decimal Min { get; set; }

        [Required]
        public decimal Max { get; set; }

        public ICollection<SafetyFunction> SafetyFunctions { get; set; }
        public ICollection<Subsystem> Subsystems { get; set; }
        public ICollection<Architecture> Architectures { get; set; }
        public ICollection<TypeOfLogic> TypeOfLogics { get; set; }
    }
}

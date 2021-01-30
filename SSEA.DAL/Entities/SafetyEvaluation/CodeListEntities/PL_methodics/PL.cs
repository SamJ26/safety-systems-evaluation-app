using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL_methodics
{
    public class PL : EntityBase
    {
        [StringLength(2)]
        public char Label { get; set; }

        public ICollection<SafetyFunction> SafetyFunctions { get; set; }
        public ICollection<Subsystem> Subsystems { get; set; }
        public ICollection<TypeOfLogic> TypeOfLogics { get; set; }
    }
}

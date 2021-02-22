using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL
{
    [Table("PFHd")]
    public class PFHd : CodeListEntityBase
    {
        [Required]
        [StringLength(20)]
        public string Label { get; set; }

        public decimal Min { get; set; }
        public decimal Max { get; set; }

        public ICollection<SafetyFunction> SafetyFunctionsSILCL { get; set; }
        public ICollection<SafetyFunction> SafetyFunctionsSILresult { get; set; }
        public ICollection<Subsystem> Subsystems { get; set; }
        public ICollection<Architecture> Architectures { get; set; }
        public ICollection<TypeOfLogic> TypeOfLogics { get; set; }
    }
}

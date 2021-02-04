using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL_methodics
{
    [Table("HFT")]
    public class HFT : EntityBase
    {
        [Required]
        public uint Value { get; set; }

        public ICollection<Subsystem> Subsystems { get; set; }
        public ICollection<Architecture> Architectures { get; set; }
    }
}

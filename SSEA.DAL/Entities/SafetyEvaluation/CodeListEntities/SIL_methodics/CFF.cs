using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL_methodics
{
    public class CFF : EntityBase
    {
        [Required]
        public uint CCF_min { get; set; }

        [Required]
        public uint CCF_max { get; set; }

        [Required]
        public double Beta { get; set; }

        public ICollection<Subsystem> Subsystems { get; set; }
    }
}

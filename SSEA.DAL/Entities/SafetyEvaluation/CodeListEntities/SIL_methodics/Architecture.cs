using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL_methodics
{
    [Table("Architecture")]
    public class Architecture : EntityBase
    {
        [Required]
        [StringLength(2)]
        public string Label { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public bool Logic { get; set; }
        public bool Diagnostic { get; set; }
        public short Channels { get; set; }
        public double SFF_min { get; set; }
        public double SFF_max { get; set; }

        public HFT HFT { get; set; }
        public PFHd PFHd_max { get; set; }

        public ICollection<Subsystem> Subsystems { get; set; }
        public ICollection<TypeOfLogic> TypeOfLogics { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL_methodics
{
    public class Architecture : EntityBase
    {
        [Required]
        [StringLength(1)]
        public char Label { get; set; }

        [Required]
        public bool Logic { get; set; }

        [Required]
        public bool Diagnostic { get; set; }

        [Required]
        public uint Channels { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        public SFF SFF_min { get; set; }

        [Required]
        public SFF SFF_max { get; set; }

        [Required]
        public HFT HFT { get; set; }

        [Required]
        public PFHd PFHd_max { get; set; }
    }
}

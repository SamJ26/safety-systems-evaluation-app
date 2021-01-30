using SSEA.DAL.Entities.SafetyEvaluation.JoinEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL_methodics
{
    public class SFF : EntityBase
    {
        [Required]
        [StringLength(100)]
        public string ComponentName { get; set; }

        [Required]
        [StringLength(100)]
        public string FailureMode { get; set; }

        [Required]
        public uint Value { get; set; }

        public ICollection<ElementSFF> ElementSFFs { get; set; }
        public ICollection<Architecture> Architectures { get; set; }
    }
}

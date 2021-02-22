using SSEA.DAL.Entities.SafetyEvaluation.JoinEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL
{
    [Table("SFF")]
    public class SFF : CodeListEntityBase
    {
        [Required]
        [StringLength(100)]
        public string ComponentName { get; set; }

        [StringLength(100)]
        public string FailureMode { get; set; }

        public uint Value { get; set; }

        public ICollection<ElementSFF> ElementSFFs { get; set; }
    }
}

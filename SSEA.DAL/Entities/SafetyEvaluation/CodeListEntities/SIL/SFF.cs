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
        [StringLength(200)]
        public string ComponentNameCZ { get; set; }

        [Required]
        [StringLength(200)]
        public string FailureModeCZ { get; set; }

        [StringLength(100)]
        public string ComponentNameEN { get; set; }
      
        [StringLength(100)]
        public string FailureModeEN { get; set; }

        public uint Value { get; set; }

        public ICollection<ElementSFF> ElementSFFs { get; set; }
    }
}

using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL;
using SSEA.DAL.Entities.SafetyEvaluation.JoinEntities;
using SSEA.DAL.Entities.System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.MainEntities
{
    [Table("Element")]
    public class Element : ExtendedEntityBase
    {
        public short OrderNum { get; set; }
        public double? B10d { get; set; }

        [StringLength(50)]
        public string CatalogNumber { get; set; }

        [ForeignKey("Producer_Id")]
        public Producer Producer { get; set; }

        [ForeignKey("Subsystem_Id")]
        public Subsystem Subsystem { get; set; }

        [ForeignKey("DC_Id")]
        public DC DC { get; set; }

        // Properties for PL methodics:
        public double? Nop { get; set; }
        public double? Hop { get; set; }
        public double? Dop { get; set; }
        public double? Tcycles { get; set; }
        public double? MTTFdCounted { get; set; }

        [ForeignKey("MTTFdResult_Id")]
        public MTTFd MTTFdResult { get; set; }

        // Properties for SIL methodics:
        public double? C { get; set; }
        public double? LambdaC { get; set; }

        public ICollection<ElementSFF> ElementSFFs { get; set; }
    }
}

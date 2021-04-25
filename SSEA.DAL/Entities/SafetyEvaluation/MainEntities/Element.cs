using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL;
using SSEA.DAL.Entities.SafetyEvaluation.JoinEntities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSEA.DAL.Entities.SafetyEvaluation.MainEntities
{
    [Table("Element")]
    public class Element : ExtendedEntityBase
    {
        public double? B10d { get; set; }

        [StringLength(50)]
        public string CatalogNumber { get; set; }

        [Column("Producer_Id")]
        public int ProducerId { get; set; }
        public Producer Producer { get; set; }

        [Column("Subsystem_Id")]
        public int SubsystemId { get; set; }
        public Subsystem Subsystem { get; set; }

        [Column("DC_Id")]
        public int DCId { get; set; }
        public DC DC { get; set; }

        // Properties for PL methodics:

        public double? Nop { get; set; }
        public double? Hop { get; set; }
        public double? Dop { get; set; }
        public double? Tcycles { get; set; }
        public double? CalculatedMTTFd { get; set; }

        [Column("ResultantMTTFd_Id")]
        public int? ResultantMTTFdId { get; set; }
        public MTTFd ResultantMTTFd { get; set; }

        // Properties for SIL methodics:

        public double? C { get; set; }
        public double? LambdaD { get; set; }
        public double SummedSFF { get; set; }


        public ICollection<ElementSFF> ElementSFFs { get; set; }
    }
}

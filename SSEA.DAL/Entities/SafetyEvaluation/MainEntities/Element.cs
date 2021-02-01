using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL_methodics;
using SSEA.DAL.Entities.SafetyEvaluation.JoinEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.MainEntities
{
    [Table("Element")]
    public class Element : ExtendedEntityBase
    {
        public short OrderNum { get; set; }
        public double? B10d { get; set; }

        [ForeignKey("Producer_Id")]
        public Producer Producer { get; set; }

        [ForeignKey("Subsystem_Id")]
        public Subsystem Subsystem { get; set; }

        [ForeignKey("DC_Id")]
        public DC DC { get; set; }

        // Properties for PL methodics:
        public double? n_op { get; set; }
        public double? h_op { get; set; }
        public double? d_op { get; set; }
        public double? t_cycles { get; set; }
        public double? MTTFd_counted { get; set; }

        [ForeignKey("MTTFd_result_Id")]
        public MTTFd MTTFd_result { get; set; }

        // Properties for SIL methodics:
        public double? C { get; set; }
        public double? lambda_c { get; set; }

        public ICollection<ElementSFF> ElementSFFs { get; set; }
    }
}

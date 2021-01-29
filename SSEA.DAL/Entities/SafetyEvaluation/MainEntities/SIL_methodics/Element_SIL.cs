using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.MainEntities.SIL_methodics
{
    public class Element_SIL : ExtendedEntityBase
    {
        public short Order { get; set; }
        public double C { get; set; }
        public double B10d { get; set; }
        public double lambda_c { get; set; }

        // public virtual DC DC_result { get; set; }
        // public virtual Subsystem_SIL Subsystem { get; set; }
        // public virtual ICollection<ElementSFF> ElementSFFs { get; set; }
    }
}

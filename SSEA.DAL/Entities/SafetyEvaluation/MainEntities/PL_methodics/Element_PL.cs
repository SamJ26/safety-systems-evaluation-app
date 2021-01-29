using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL_methodics;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.MainEntities.PL_methodics
{
    public class Element_PL : ExtendedEntityBase
    {
        public short Order { get; set; }
        public double n_op { get; set; }
        public double h_op { get; set; }
        public double d_op { get; set; }
        public double t_cycles { get; set; }
        public double B10d { get; set; }
        public double MTTFd_counted { get; set; }

        // public virtual MTTFd MTTFd_result { get; set; }
        // public virtual DC DC { get; set; }
        // public virtual Producer Producer { get; set; }
        // public virtual Subsystem_PL Subsystem { get; set; }
    }
}

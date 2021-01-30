using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.JoinEntities
{
    public class SubsystemCCF : EntityBase
    {
        public int SubsystemId { get; set; }
        public Subsystem Subsystem { get; set; }
        public int CCF_Id { get; set; }
        public CCF CCF { get; set; }
    }
}

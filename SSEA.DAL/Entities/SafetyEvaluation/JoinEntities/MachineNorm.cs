using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.JoinEntities
{
    public class MachineNorm : EntityBase
    {
        public int MachineId { get; set; }
        public Machine Machine { get; set; }
        public int NormId { get; set; }
        public Norm Norm { get; set; }
    }
}

using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.JoinEntities
{
    [Table("MachineNorm")]
    public class MachineNorm : ExtendedEntityBase
    {
        public int MachineId { get; set; }
        public int NormId { get; set; }

        public Machine Machine { get; set; }
        public Norm Norm { get; set; }
    }
}

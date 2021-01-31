using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.JoinEntities
{
    [Table("MachineNorm")]
    public class MachineNorm : EntityBase
    {
        public int MachineId { get; set; }
        public int NormId { get; set; }

        [ForeignKey("Machine_Id")]
        public Machine Machine { get; set; }

        [ForeignKey("Norm_Id")]
        public Norm Norm { get; set; }
    }
}

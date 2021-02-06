using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL
{
    [Table("CFF")]
    public class CFF : EntityBase
    {
        public short CCF_min { get; set; }
        public short CCF_max { get; set; }
        public double Beta { get; set; }

        public ICollection<Subsystem> Subsystems { get; set; }
    }
}

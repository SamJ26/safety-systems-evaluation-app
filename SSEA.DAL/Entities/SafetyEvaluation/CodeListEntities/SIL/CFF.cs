using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL
{
    [Table("CFF")]
    public class CFF : CodeListEntityBase
    {
        public short MinCCF { get; set; }
        public short MaxCCF { get; set; }
        public double Beta { get; set; }

        public ICollection<Subsystem> Subsystems { get; set; }
    }
}

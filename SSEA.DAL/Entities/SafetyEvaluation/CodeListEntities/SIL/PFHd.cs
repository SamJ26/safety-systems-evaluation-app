using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL
{
    [Table("PFHd")]
    public class PFHd : CodeListEntityBase
    {
        public short ValueSIL { get; set; }
        public float MinPFHd { get; set; }
        public float MaxPFHd { get; set; }
    }
}

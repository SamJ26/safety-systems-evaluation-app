using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL
{
    [Table("Architecture")]
    public class Architecture : CodeListEntityBase
    {
        [Required]
        [StringLength(2)]
        public string Label { get; set; }

        [StringLength(250)]
        public string DescriptionCZ { get; set; }

        public bool Logic { get; set; }
        public bool Diagnostic { get; set; }
        public short Channels { get; set; }
        public double MinSFF { get; set; }
        public double MaxSFF { get; set; }
        public short HFT { get; set; }

        [ForeignKey("MaxPFHd_Id")]
        public PFHd MaxPFHd { get; set; }

        public ICollection<TypeOfLogic> TypeOfLogics { get; set; }
    }
}

using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common
{
    [Table("DC")]
    public class DC : CodeListEntityBase
    {
        [Required]
        [StringLength(10)]
        public string ValueCZ { get; set; }

        [StringLength(10)]
        public string ValueEN { get; set; }

        public short Min { get; set; }
        public short Max { get; set; }
    }
}

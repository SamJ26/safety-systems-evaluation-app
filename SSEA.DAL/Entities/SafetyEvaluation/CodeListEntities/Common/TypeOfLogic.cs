using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common
{
    [Table("TypeOfLogic")]
    public class TypeOfLogic : EntityBase
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int SI { get; set; }
        public int SO { get; set; }
        public bool Communication { get; set; }
        public int? AccessPoints_MaxCount { get; set; }
        public uint? EthernetAdresses_MaxCount { get; set; }

        [ForeignKey("PL_max_Id")]
        public PerformanceLevel PL_max { get; set; }

        [ForeignKey("Category_max_Id")]
        public Category Category_max { get; set; }

        [ForeignKey("SIL_max_Id")]
        public PFHd SIL_max { get; set; }

        [ForeignKey("Architecture_max_Id")]
        public Architecture Architecture_max { get; set; }

        public ICollection<Machine> Machines { get; set; }
    }
}

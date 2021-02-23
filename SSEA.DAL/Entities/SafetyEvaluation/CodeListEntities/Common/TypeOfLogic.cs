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
    public class TypeOfLogic : CodeListEntityBase
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int SI { get; set; }
        public int SO { get; set; }
        public bool Communication { get; set; }
        public int? AccessPointsMaxCount { get; set; }
        public uint? EthernetAdressesMaxCount { get; set; }

        [ForeignKey("MaxPL_Id")]
        public PerformanceLevel MaxPL { get; set; }

        [ForeignKey("MaxCategory_Id")]
        public Category MaxCategory { get; set; }

        [ForeignKey("MaxSIL_Id")]
        public PFHd MaxSIL { get; set; }

        [ForeignKey("MaxArchitecture_Id")]
        public Architecture MaxArchitecture { get; set; }
    }
}

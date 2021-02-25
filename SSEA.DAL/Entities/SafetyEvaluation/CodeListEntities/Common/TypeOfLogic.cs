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
        public string NameCZ { get; set; }

        [StringLength(50)]
        public string NameEN { get; set; }

        [StringLength(250)]
        public string DescriptionCZ { get; set; }

        [StringLength(250)]
        public string DescriptionEN { get; set; }

        public int SI { get; set; }
        public int SO { get; set; }
        public bool Communication { get; set; }
        public int? AccessPointsMaxCount { get; set; }
        public uint? EthernetAdressesMaxCount { get; set; }

        [Column("MaxPL_Id")]
        public int MaxPLId { get; set; }
        public PerformanceLevel MaxPL { get; set; }

        [Column("MaxCategory_Id")]
        public int MaxCategoryId { get; set; }
        public Category MaxCategory { get; set; }

        [Column("MaxSIL_Id")]
        public int MaxSILId { get; set; }
        public PFHd MaxSIL { get; set; }

        [Column("MaxArchitecture_Id")]
        public int MaxArchitectureId { get; set; }
        public Architecture MaxArchitecture { get; set; }
    }
}

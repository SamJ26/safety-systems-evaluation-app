using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL_methodics;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL_methodics;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common
{
    public class TypeOfLogic : EntityBase
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public uint SI { get; set; }
        public uint SO { get; set; }
        public uint? AccessPoints_MaxCount { get; set; }
        public uint? EthernetAdresses_MaxCount { get; set; }
        public bool Communication { get; set; }

        public PL PL_max { get; set; }
        public Category Category_max { get; set; }
        public PFHd SIL_max { get; set; }
        public Architecture Architecture_max { get; set; }

        public ICollection<Machine> Machines { get; set; }
    }
}

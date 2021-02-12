using SSEA.BL.Models.SafetyEvaluation.CodeListModels.PL;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.SIL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common
{
    public class TypeOfLogicModel : ModelBase
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int SI { get; set; }
        public int SO { get; set; }
        public bool Communication { get; set; }
        public int AccessPoints_MaxCount { get; set; }
        public uint EthernetAdresses_MaxCount { get; set; }

        [Required]
        public PLModel PL_max { get; set; }
        
        [Required]
        public CategoryModel Category_max { get; set; }

        [Required]
        public PFHdModel SIL_max { get; set; }

        [Required]
        public ArchitectureModel Architecture_max { get; set; }
    }
}

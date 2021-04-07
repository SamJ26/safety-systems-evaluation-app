using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common
{
    public class OperationPrinciple : CodeListEntityBase
    {
        [Required]
        [StringLength(20)]
        public string NameCZ { get; set; }

        [StringLength(20)]
        public string NameEN { get; set; }

        [StringLength(250)]
        public string DescriptionCZ { get; set; }

        [StringLength(250)]
        public string DescriptionEN { get; set; }
    }
}

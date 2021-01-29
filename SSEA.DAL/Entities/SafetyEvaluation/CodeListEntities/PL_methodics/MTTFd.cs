using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL_methodics
{
    public class MTTFd : EntityBase
    {
        [Required]
        [StringLength(10)]
        public string Value { get; set; }

        [Required]
        public uint Min { get; set; }

        [Required]
        public uint Max { get; set; }
    }
}

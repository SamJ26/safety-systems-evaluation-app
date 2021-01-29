using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.MainEntities.Common
{
    public class AccessPoint : ExtendedEntityBase
    {
        [Required]
        [StringLength(100)]
        public string ShortName { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        // public virtual Machine Machine { get; set; }
    }
}

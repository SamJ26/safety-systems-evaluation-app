using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.MainEntities
{
    public class AccessPoint : ExtendedEntityBase
    {
        [Required]
        [StringLength(100)]
        public string ShortName { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public Machine Machine { get; set; }
    }
}

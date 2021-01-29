﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.MainEntities.Common
{
    public class Producer : ExtendedEntityBase
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string CountryOfOrigin { get; set; }

        // public virtual Machine Machine { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.MainEntities
{
    public class Producer : ExtendedEntityBase
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string CountryOfOrigin { get; set; }

        public ICollection<Machine> Machines { get; set; }
    }
}

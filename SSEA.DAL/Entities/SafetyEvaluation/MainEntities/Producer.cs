using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.SafetyEvaluation.MainEntities
{
    [Table("Producer")]
    public class Producer : ExtendedEntityBase
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string CountryOfOrigin { get; set; }

        public ICollection<Machine> Machines { get; set; }
        public ICollection<Element> Elements { get; set; }
    }
}

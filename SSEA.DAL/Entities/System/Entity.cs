using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.System
{
    [Table("SY_Entity")]
    public class Entity : EntityBase
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public ICollection<State> States { get; set; }
    }
}

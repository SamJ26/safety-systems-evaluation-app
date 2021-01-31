using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.System
{
    [Table("SY_State")]
    public class State : EntityBase
    {
        [Required]
        [StringLength(100)]
        public string StateName { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public bool Valid { get; set; }
        public bool InitialState { get; set; }
        public bool FinalState { get; set; }

        [Column("Entity_Id")]
        public Entity Entity { get; set; }

        public ICollection<StateTransition> StateTransitions_current { get; set; }
        public ICollection<StateTransition> StateTransitions_next { get; set; }
    }
}

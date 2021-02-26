using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities.System
{
    [Table("SY_StateTransition")]
    public class StateTransition : EntityBase
    {
        [StringLength(200)]
        public string Note { get; set; }

        public bool Valid { get; set; }

        [Column("CurrentState_Id")]
        public int CurrentStateId { get; set; }
        public State CurrentState { get; set; }

        [Column("NextState_Id")]
        public int NextStateId { get; set; }
        public State NextState { get; set; }
    }
}

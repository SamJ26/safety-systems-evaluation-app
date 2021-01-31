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

        [Column("CurrentState_Id")]
        public State CurrentState { get; set; }

        [Column("NextState_Id")]
        public State NextState { get; set; }
    }
}

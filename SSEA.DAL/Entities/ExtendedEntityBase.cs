using SSEA.DAL.Entities.System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities
{
    public abstract class ExtendedEntityBase : EntityBase, IExtendedEntityBase
    {
        public int IdCreated { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public int? IdUpdated { get; set; }
        public DateTime? DateTimeUpdated { get; set; }

        [Column("CurrentState_Id")]
        public int CurrentStateId { get; set; }
        public State CurrentState { get; set; }
    }
}

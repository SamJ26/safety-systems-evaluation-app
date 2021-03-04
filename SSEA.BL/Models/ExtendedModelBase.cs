using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.BL.Models
{
    public abstract class ExtendedModelBase : ModelBase
    {
        public int IdCreated { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public int? IdUpdated { get; set; }
        public DateTime? DateTimeUpdated { get; set; }
        public StateModel CurrentState { get; set; }
    }
}

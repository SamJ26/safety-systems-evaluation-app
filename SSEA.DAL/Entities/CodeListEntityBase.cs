using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SSEA.DAL.Entities
{
    public abstract class CodeListEntityBase : EntityBase, IExtendedEntityBase
    {
        protected CodeListEntityBase()
        {
            IsValid = true;
        }

        public int IdCreated { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public int? IdUpdated { get; set; }
        public DateTime? DateTimeUpdated { get; set; }

        [DefaultValue(true)]
        public bool IsValid { get; set; }
    }
}

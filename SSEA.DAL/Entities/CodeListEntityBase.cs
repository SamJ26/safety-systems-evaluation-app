using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.DAL.Entities
{
    public abstract class CodeListEntityBase : EntityBase, IExtendedEntityBase
    {
        public int IdCreated { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public int? IdUpdated { get; set; }
        public DateTime? DateTimeUpdated { get; set; }
        public bool IsValid { get; set; }
    }
}

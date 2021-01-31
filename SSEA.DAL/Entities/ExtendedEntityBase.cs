using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.DAL.Entities
{
    public abstract class ExtendedEntityBase : EntityBase
    {
        public int Id_created { get; set; }
        public DateTime DT_created { get; set; }
        public int? Id_updated { get; set; }
        public DateTime? DT_updated { get; set; }
    }
}

using SSEA.DAL.Entities.System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SSEA.DAL.Entities
{
    public abstract class ExtendedEntityBase : EntityBase, IExtendedEntityBase
    {
        public int Id_created { get; set; }
        public DateTime DT_created { get; set; }
        public int? Id_updated { get; set; }
        public DateTime? DT_updated { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.BL.Models
{
    public abstract class ExtendedModelBase : ModelBase
    {
        public int Id_created { get; set; }
        public DateTime DT_created { get; set; }
        public int? Id_updated { get; set; }
        public DateTime? DT_updated { get; set; }
    }
}

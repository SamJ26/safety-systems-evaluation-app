using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.DAL.Entities
{
    public interface IExtendedEntityBase
    {
        int Id_created { get; set; }
        DateTime DT_created { get; set; }
        int? Id_updated { get; set; }
        DateTime? DT_updated { get; set; }
    }
}

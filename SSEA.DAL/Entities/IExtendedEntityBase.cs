using SSEA.DAL.Entities.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.DAL.Entities
{
    public interface IExtendedEntityBase
    {
        int IdCreated { get; set; }
        DateTime DateTimeCreated { get; set; }
        int? IdUpdated { get; set; }
        DateTime? DateTimeUpdated { get; set; }
    }
}

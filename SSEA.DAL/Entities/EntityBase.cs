using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.DAL.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public bool IsRemoved { get; set; } = false;
    }
}

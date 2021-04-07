using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SSEA.DAL.Entities
{
    public abstract class CodeListEntityBase : EntityBase
    {
        protected CodeListEntityBase()
        {
            IsValid = true;
        }

        [DefaultValue(true)]
        public bool IsValid { get; set; }
    }
}

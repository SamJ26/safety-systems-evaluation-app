using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.BL.Models
{
    public class StateModel : ModelBase
    {
        public string StateName { get; set; }
        public string Description { get; set; }
        public int StateNumber { get; set; }
        public bool Valid { get; set; }
    }
}

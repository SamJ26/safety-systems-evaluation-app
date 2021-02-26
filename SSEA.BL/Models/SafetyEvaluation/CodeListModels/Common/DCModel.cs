using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common
{
    public class DCModel : CodeListModelBase
    {
        public string Value { get; set; }
        public short Min { get; set; }
        public short Max { get; set; }
    }
}

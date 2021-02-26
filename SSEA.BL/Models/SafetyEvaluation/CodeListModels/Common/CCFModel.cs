using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common
{
    public class CCFModel : CodeListModelBase
    {
        public string Description { get; set; }
        public string Type { get; set; }
        public uint Points { get; set; }
    }
}

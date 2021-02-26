using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.PL
{
    public class FModel : CodeListModelBase
    {
        public string Value { get; set; }
        public string Description { get; set; }
    }
}

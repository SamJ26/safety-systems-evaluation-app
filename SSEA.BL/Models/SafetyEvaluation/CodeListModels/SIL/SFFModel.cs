using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.SIL
{
    public class SFFModel : CodeListModelBase
    {
        public string ComponentName { get; set; }
        public string FailureMode { get; set; }
        public uint Value { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.SIL
{
    public class FrModel : CodeListModelBase
    {
        public string FrequencyOfThreat { get; set; }
        public short Value { get; set; }
    }
}

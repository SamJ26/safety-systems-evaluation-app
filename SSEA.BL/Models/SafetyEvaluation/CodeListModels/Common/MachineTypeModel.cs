using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common
{
    public class MachineTypeModel : CodeListModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

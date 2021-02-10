using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels
{
    public class AccessPointListModel : ModelBase
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        // public State CurrentState { get; set; }
    }
}

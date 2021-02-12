using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels
{
    public class ProducerDetailModel : ExtendedModelBase
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string CountryOfOrigin { get; set; }
    }
}

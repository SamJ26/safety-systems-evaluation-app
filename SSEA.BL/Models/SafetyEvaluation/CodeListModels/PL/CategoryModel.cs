using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.PL
{
    public class CategoryModel : ModelBase
    {
        [Required]
        [StringLength(2)]
        public string Label { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [StringLength(250)]
        public string Requirements { get; set; }

        [StringLength(250)]
        public string FailureBehavior { get; set; }

        [Required]
        public bool Logic { get; set; }

        [Required]
        public short Channels { get; set; }

        [Required]
        public bool CCF_relevant { get; set; }

        [Required]
        public MTTFdModel MTTFd_min { get; set; }

        [Required]
        public MTTFdModel MTTFd_max { get; set; }

        [Required]
        public DCModel DC_min { get; set; }

        [Required]
        public DCModel DC_max { get; set; }
    }
}
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.PL
{
    public class CategoryModel : CodeListModelBase
    {
        public string Label { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public string FailureBehavior { get; set; }
        public bool Logic { get; set; }
        public short Channels { get; set; }
        public bool RelevantCCF { get; set; }
        public MTTFdModel MinMTTFd { get; set; }
        public MTTFdModel MaxMTTFd { get; set; }
        public DCModel MinD { get; set; }
        public DCModel MaxDC { get; set; }
    }
}
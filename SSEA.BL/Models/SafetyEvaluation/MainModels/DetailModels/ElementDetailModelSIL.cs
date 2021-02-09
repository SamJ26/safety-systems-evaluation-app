using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.PL;
using SSEA.BL.Models.SafetyEvaluation.JoinModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels
{
    public class ElementDetailModelSIL : ExtendedModelBase
    {
        public short OrderNum { get; set; }
        public double B10d { get; set; }
        public double C { get; set; }
        public double Lambda_c { get; set; }

        public ProducerDetailModel Producer { get; set; }
        public SubsystemListModel Subsystem { get; set; }
        public DCModel DC { get; set; }
        public MTTFdModel MTTFd_result { get; set; }

        public ICollection<ElementSFFModel> ElementSFFs { get; set; }

        // public State CurrentState { get; set; }
    }
}

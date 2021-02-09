using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.PL;
using SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels
{
    public class ElementDetailModelPL : ExtendedModelBase
    {
        public short OrderNum { get; set; }
        public double B10d { get; set; }
        public double n_op { get; set; }
        public double h_op { get; set; }
        public double d_op { get; set; }
        public double t_cycles { get; set; }
        public double MTTFd_counted { get; set; }

        public ProducerDetailModel Producer { get; set; }
        public SubsystemListModel Subsystem { get; set; }
        public DCModel DC { get; set; }
        public MTTFdModel MTTFd_result { get; set; }

        // public State CurrentState { get; set; }
    }
}

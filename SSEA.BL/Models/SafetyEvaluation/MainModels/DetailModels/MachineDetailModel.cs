using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using SSEA.BL.Models.SafetyEvaluation.JoinModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels
{
    public class MachineDetailModel : ExtendedModelBase
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        public bool Communication { get; set; }

        public bool HMI { get; set; }
        public bool PLC { get; set; }
        public bool MachineHelp { get; set; }
        public bool CodeProtection { get; set; }
        public bool SecurityOfSafetyParts { get; set; }
        public bool SafetyMasterInPlace { get; set; }

        public ProducerDetailModel Producer { get; set; }
        public EvaluationMethodModel EvaluationMethod { get; set; }
        public MachineTypeModel MachineType { get; set; }
        public TypeOfLogicModel TypeOfLogic { get; set; }

        public ICollection<AccessPointListModel> AccessPoints { get; set; }
        public ICollection<MachineNormModel> MachineNorms { get; set; }
        
        // public State CurrentState { get; set; }
    }
}

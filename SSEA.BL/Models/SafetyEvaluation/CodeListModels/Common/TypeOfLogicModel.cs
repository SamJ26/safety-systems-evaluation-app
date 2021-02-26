using SSEA.BL.Models.SafetyEvaluation.CodeListModels.PL;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.SIL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common
{
    public class TypeOfLogicModel : CodeListModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int SI { get; set; }
        public int SO { get; set; }
        public bool Communication { get; set; }
        public int AccessPointsMaxCount { get; set; }
        public uint EthernetAdressesMaxCount { get; set; }
        public PLModel MaxPL { get; set; }
        public CategoryModel MaxCategory { get; set; }
        public PFHdModel MaxSI { get; set; }
        public ArchitectureModel MaxArchitecture { get; set; }
    }
}

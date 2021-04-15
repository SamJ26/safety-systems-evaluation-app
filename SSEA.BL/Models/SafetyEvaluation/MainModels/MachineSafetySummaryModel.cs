using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.BL.Models.SafetyEvaluation.MainModels
{
    public class MachineSafetySummaryModel
    {
        public int MachineId { get; set; }
        public string MachineName { get; set; }
        public StateModel MachineState { get; set; }
        public string Message { get; set; }
        public Dictionary<AccessPointInfo, List<SafetyFunctionInfo>> Summary { get; set; }
    }

    public class AccessPointInfo
    {
        public int AccessPointId { get; set; }
        public string AccessPointName { get; set; }
        public StateModel AccessPointState { get; set; }
    }

    public class SafetyFunctionInfo
    {
        public int SafetyFunctionId { get; set; }
        public string SafetyFunctionName { get; set; }
        public StateModel SafetyFunctionState { get; set; }
    }
}

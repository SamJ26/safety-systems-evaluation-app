using SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SSEA.BL.Services.Interfaces
{
    public interface ISafetyIntegrityLevelService
    {
        /// <summary>
        /// Method for evaluation of subsystem's properties using data of elements
        /// </summary>
        /// <param name="subsystem"> Subsystem for evaluation </param>
        /// <returns> Method interacts with database so it returns async task </returns>
        Task EvaluateSubsystemAsync(SubsystemDetailModelSIL subsystem);
    }
}

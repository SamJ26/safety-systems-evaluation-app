using SSEA.BL.Models.SafetyEvaluation.CodeListModels.PL;
using SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels;
using System.Threading.Tasks;

namespace SSEA.BL.Services.Interfaces
{
    public interface IPerformanceLevelService
    {
        /// <summary>
        /// Method for evaluation of required performance level
        /// </summary>
        /// <param name="s"> Selected severity of injury </param>
        /// <param name="f"> Selected frequency of exposure </param>
        /// <param name="p"> Selected probability of avoiding injury </param>
        /// <returns> Id of record which represents determined value </returns>
        Task<PLModel> GetRequiredPLAsync(SModel s, FModel f, PModel p);

        /// <summary>
        /// Method for evaluation of subsystem's properties using data of elements
        /// </summary>
        /// <param name="subsystem"> Subsystem for evaluation </param>
        /// <returns> Method interacts with database so it returns async task </returns>
        Task EvaluateSubsystemAsync(SubsystemDetailModelPL subsystem);

        /// <summary>
        /// Method for evaluation of whole safety function
        /// </summary>
        /// <param name="safetyFunction"> Safety function for evaluation </param>
        /// <returns> True if resultant PL is bigger than required PL, otherwise false </returns>
        Task<bool> EvaluateSafetyFunctionAsync(SafetyFunctionDetailModelPL safetyFunction);
    }
}

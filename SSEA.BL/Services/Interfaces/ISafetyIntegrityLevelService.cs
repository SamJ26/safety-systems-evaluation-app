using SSEA.BL.Models.SafetyEvaluation.CodeListModels.SIL;
using SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels;
using System.Threading.Tasks;

namespace SSEA.BL.Services.Interfaces
{
    public interface ISafetyIntegrityLevelService
    {
        /// <summary>
        /// Method for evaluation of required SIL (Safety Integrity Level)
        /// </summary>
        /// <param name="se"> Severity </param>
        /// <param name="fr"> Frequency </param>
        /// <param name="pr"> Probability </param>
        /// <param name="av"> Probability of avoiding danger </param>
        /// <returns></returns>
        Task<PFHdModel> GetRequiredSILAsync(SeModel se, FrModel fr, PrModel pr, AvModel av);

        /// <summary>
        /// Method for evaluation of subsystem's properties using data of elements
        /// </summary>
        /// <param name="subsystem"> Subsystem for evaluation </param>
        /// <returns> Method interacts with database so it returns async task </returns>
        Task EvaluateSubsystemAsync(SubsystemDetailModelSIL subsystem);

        /// <summary>
        /// Method for evaluation of whole safety function
        /// </summary>
        /// <param name="safetyFunction"> Safety function for evaluation </param>
        /// <returns> True if resultant SIL is bigger than required SIL, otherwise false </returns>
        Task<bool> EvaluateSafetyFunctionAsync(SafetyFunctionDetailModelSIL safetyFunction);
    }
}

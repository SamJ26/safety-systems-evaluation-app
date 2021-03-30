using SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
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
        Task<int> GetRequiredPLAsync(S s, F f, P p);

        /// <summary>
        /// Method for evaluation of subsystem's properties using data of elements
        /// </summary>
        /// <param name="subsystem"> Subsystem for evaluation </param>
        /// <returns> Method interacts with database so it returns async task </returns>
        Task EvaluateSubsystem(SubsystemDetailModelPL subsystem);
    }
}

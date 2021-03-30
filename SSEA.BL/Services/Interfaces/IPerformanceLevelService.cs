using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System.Threading.Tasks;

namespace SSEA.BL.Services.Interfaces
{
    public interface IPerformanceLevelService
    {
        Task<int> GetRequiredPLAsync(S s, F f, P p);
        Task<bool> EvaluateSubsystem(Subsystem subsystem);
        bool IsSubsystemValid(Subsystem subsystem);



        //bool IsCCFValid(HashSet<CCFModel> items);
        //int GetMTTFdForSubsystem(MTTFd mttfd1, MTTFd mttf2 = null);

    }
}

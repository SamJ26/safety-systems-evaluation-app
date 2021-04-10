using Microsoft.EntityFrameworkCore;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SSEA.DAL.Repositories
{
    public class CodeListRepository
    {
        private readonly AppDbContext dbContext;

        public CodeListRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ICollection<OperationPrinciple>> GetAllOperationPrinciplesAsync()
        {
            return await dbContext.OperationPrinciples.AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<CCF>> GetAllCCFsAsync()
        {
            return await dbContext.CCFs.AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<DC>> GetAllDCsAsync()
        {
            return await dbContext.DCs.AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<EvaluationMethod>> GetAllEvaluationMethodsAsync()
        {
            return await dbContext.EvaluationMethods.AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<MachineType>> GetAllMachineTypesAsync()
        {
            return await dbContext.MachineTypes.AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<Norm>> GetAllNormsAsync()
        {
            return await dbContext.Norms.AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<TypeOfFunction>> GetAllTypeOfFunctionsAsync()
        {
            return await dbContext.TypeOfFunctions.AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<TypeOfLogic>> GetAllTypeOfLogicsAsync()
        {
            return await dbContext.TypeOfLogics.Include(tol => tol.MaxArchitecture)
                                               .Include(tol => tol.MaxPL)
                                               .Include(tol => tol.MaxCategory)
                                               .Include(tol => tol.MaxSIL)
                                               .AsNoTracking()
                                               .ToListAsync();
        }

        public async Task<ICollection<TypeOfSubsystem>> GetAllTypeOfSubsystemsAsync()
        {
            return await dbContext.TypeOfSubsystems.AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<Category>> GetAllCategorysAsync()
        {
            return await dbContext.Categories.Include(c => c.MinMTTFd)
                                             .Include(c => c.MaxMTTFd)
                                             .Include(c => c.MinDC)
                                             .Include(c => c.MaxDC)
                                             .AsNoTracking()
                                             .ToListAsync();
        }

        public async Task<ICollection<F>> GetAllFsAsync()
        {
            return await dbContext.Fs.AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<MTTFd>> GetAllMTTFdsAsync()
        {
            return await dbContext.MTTFds.AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<PerformanceLevel>> GetAllPLsAsync()
        {
            return await dbContext.PerformanceLevels.AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<P>> GetAllPsAsync()
        {
            return await dbContext.Ps.AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<S>> GetAllSsAsync()
        {
            return await dbContext.Ss.AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<Architecture>> GetAllArchitecturesAsync()
        {
            return await dbContext.Architectures.Include(a => a.MaxPFHd)
                                                .AsNoTracking()
                                                .ToListAsync();
        }

        public async Task<ICollection<Av>> GetAllAvsAsync()
        {
            return await dbContext.Avs.AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<Fr>> GetAllFrsAsync()
        {
            return await dbContext.Frs.AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<PFHd>> GetAllPFHdsAsync()
        {
            return await dbContext.PFHds.AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<Pr>> GetAllPrsAsync()
        {
            return await dbContext.Prs.AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<Se>> GetAllSesAsync()
        {
            return await dbContext.Ses.AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<SFF>> GetAllSFFsAsync()
        {
            return await dbContext.SFFs.AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<Producer>> GetAllProducersAsync()
        {
            return await dbContext.Producers.AsNoTracking().ToListAsync();
        }
    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SSEA.BL.Models;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.PL;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.SIL;
using SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels;
using SSEA.DAL;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSEA.BL.Facades
{
    public class CodeListFacade
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper mapper;

        public CodeListFacade(AppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<dynamic> GetAllAsync(string typeName)
        {
            return typeName switch
            {
                "DC" => await GetAllDCModels(),
                "CCF" => await GetAllCCFModels(),
                "EvaluationMethod" => await GetAllEvaluationMethodModels(),
                "MachineType" => await GetAllMachineTypeModels(),
                "Norm" => await GetAllNormModels(),
                "TypeOfFunction" => await GetAllTypeOfFunctionModels(),
                "TypeOfLogic" => await GetAllTypeOfLogicModels(),
                "TypeOfSubsystem" => await GetAllTypeOfSubsystemModels(),
                "Category" => await GetAllCategoryModels(),
                "F" => await GetAllFModels(),
                "MTTFd" => await GetAllMTTFdModels(),
                "PL" => await GetAllPLModels(),
                "P" => await GetAllPModels(),
                "S" => await GetAllSModels(),
                "Architecture" => await GetAllArchitectureModels(),
                "Av" => await GetAllAvModels(),
                "CFF" => await GetAllCFFModels(),
                "Fr" => await GetAllFrModels(),
                "PFHd" => await GetAllPFHdModels(),
                "Pr" => await GetAllPrModels(),
                "Se" => await GetAllSeModels(),
                "SFF" => await GetAllSFFModels(),
                "Producer" => await GetAllProducerModels(),
                _ => null,
            };
        }

        #region GetAll methods for specific types

        private async Task<ICollection<CCFModel>> GetAllCCFModels()
        {
            var data = await dbContext.CCFs.AsNoTracking().ToListAsync();
            return mapper.Map<ICollection<CCFModel>>(data);
        }

        private async Task<ICollection<DCModel>> GetAllDCModels()
        {
            var data = await dbContext.DCs.AsNoTracking().ToListAsync();
            return mapper.Map<ICollection<DCModel>>(data);
        }

        private async Task<ICollection<EvaluationMethodModel>> GetAllEvaluationMethodModels()
        {
            var data = await dbContext.EvaluationMethods.AsNoTracking().ToListAsync();
            return mapper.Map<ICollection<EvaluationMethodModel>>(data);
        }

        private async Task<ICollection<MachineTypeModel>> GetAllMachineTypeModels()
        {
            var data = await dbContext.MachineTypes.AsNoTracking().ToListAsync();
            return mapper.Map<ICollection<MachineTypeModel>>(data);
        }

        private async Task<ICollection<NormModel>> GetAllNormModels()
        {
            var data = await dbContext.Norms.AsNoTracking().ToListAsync();
            return mapper.Map<ICollection<NormModel>>(data);
        }

        private async Task<ICollection<TypeOfFunctionModel>> GetAllTypeOfFunctionModels()
        {
            var data = await dbContext.TypeOfFunctions.AsNoTracking().ToListAsync();
            return mapper.Map<ICollection<TypeOfFunctionModel>>(data);
        }

        private async Task<ICollection<TypeOfLogicModel>> GetAllTypeOfLogicModels()
        {
            var data = await dbContext.TypeOfLogics.Include(tol => tol.MaxArchitecture)
                                                   .Include(tol => tol.MaxPL)
                                                   .Include(tol => tol.MaxCategory)
                                                   .Include(tol => tol.MaxSIL)
                                                   .AsNoTracking()
                                                   .ToListAsync();
            return mapper.Map<ICollection<TypeOfLogicModel>>(data);
        }

        private async Task<ICollection<TypeOfSubsystemModel>> GetAllTypeOfSubsystemModels()
        {
            var data = await dbContext.TypeOfSubsystems.AsNoTracking().ToListAsync();
            return mapper.Map<ICollection<TypeOfSubsystemModel>>(data);
        }

        private async Task<ICollection<CategoryModel>> GetAllCategoryModels()
        {
            var data = await dbContext.Categories.Include(c => c.MinMTTFd)
                                                 .Include(c => c.MaxMTTFd)
                                                 .Include(c => c.MinDC)
                                                 .Include(c => c.MaxDC)
                                                 .AsNoTracking()
                                                 .ToListAsync();
            return mapper.Map<ICollection<CategoryModel>>(data);
        }

        private async Task<ICollection<FModel>> GetAllFModels()
        {
            var data = await dbContext.Fs.AsNoTracking().ToListAsync();
            return mapper.Map<ICollection<FModel>>(data);
        }

        private async Task<ICollection<MTTFdModel>> GetAllMTTFdModels()
        {
            var data = await dbContext.MTTFds.AsNoTracking().ToListAsync();
            return mapper.Map<ICollection<MTTFdModel>>(data);
        }

        private async Task<ICollection<PLModel>> GetAllPLModels()
        {
            var data = await dbContext.PerformanceLevels.AsNoTracking().ToListAsync();
            return mapper.Map<ICollection<PLModel>>(data);
        }

        private async Task<ICollection<PModel>> GetAllPModels()
        {
            var data = await dbContext.Ps.AsNoTracking().ToListAsync();
            return mapper.Map<ICollection<PModel>>(data);
        }

        private async Task<ICollection<SModel>> GetAllSModels()
        {
            var data = await dbContext.Ss.AsNoTracking().ToListAsync();
            return mapper.Map<ICollection<SModel>>(data);
        }

        private async Task<ICollection<ArchitectureModel>> GetAllArchitectureModels()
        {
            var data = await dbContext.Architectures.Include(a => a.MaxPFHd)
                                                    .AsNoTracking()
                                                    .ToListAsync();
            return mapper.Map<ICollection<ArchitectureModel>>(data);
        }

        private async Task<ICollection<AvModel>> GetAllAvModels()
        {
            var data = await dbContext.Avs.AsNoTracking().ToListAsync();
            return mapper.Map<ICollection<AvModel>>(data);
        }

        private async Task<ICollection<CFFModel>> GetAllCFFModels()
        {
            var data = await dbContext.CFFs.AsNoTracking().ToListAsync();
            return mapper.Map<ICollection<CFFModel>>(data);
        }

        private async Task<ICollection<FrModel>> GetAllFrModels()
        {
            var data = await dbContext.Frs.AsNoTracking().ToListAsync();
            return mapper.Map<ICollection<FrModel>>(data);
        }

        private async Task<ICollection<PFHdModel>> GetAllPFHdModels()
        {
            var data = await dbContext.PFHds.AsNoTracking().ToListAsync();
            return mapper.Map<ICollection<PFHdModel>>(data);
        }

        private async Task<ICollection<PrModel>> GetAllPrModels()
        {
            var data = await dbContext.Prs.AsNoTracking().ToListAsync();
            return mapper.Map<ICollection<PrModel>>(data);
        }

        private async Task<ICollection<SeModel>> GetAllSeModels()
        {
            var data = await dbContext.Ses.AsNoTracking().ToListAsync();
            return mapper.Map<ICollection<SeModel>>(data);
        }

        private async Task<ICollection<SFFModel>> GetAllSFFModels()
        {
            var data = await dbContext.SFFs.AsNoTracking().ToListAsync();
            return mapper.Map<ICollection<SFFModel>>(data);
        }

        private async Task<ICollection<ProducerModel>> GetAllProducerModels()
        {
            var data = await dbContext.Producers.AsNoTracking().ToListAsync();
            return mapper.Map<ICollection<ProducerModel>>(data);
        }

        #endregion
    }
}

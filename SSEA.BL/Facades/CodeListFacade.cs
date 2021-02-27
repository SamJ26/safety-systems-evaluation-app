using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SSEA.BL.Models;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.PL;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.SIL;
using SSEA.DAL;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL;
using SSEA.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSEA.BL.Facades
{
    public class CodeListFacade
    {
        private readonly IMapper mapper;
        private readonly AppDbContext dbContext;

        public CodeListFacade(IMapper mapper,
                              AppDbContext dbContext)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
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
                _ => 0,
            };
        }

        #region GetAll methods for specific types

        private async Task<ICollection<CCFModel>> GetAllCCFModels()
        {
            var repository = new Repository<CCF>(dbContext);
            var data = await repository.GetAll().ToListAsync();
            return mapper.Map<ICollection<CCFModel>>(data);
        }

        private async Task<ICollection<DCModel>> GetAllDCModels()
        {
            var repository = new Repository<DC>(dbContext);
            var data = await repository.GetAll().ToListAsync();
            return mapper.Map<ICollection<DCModel>>(data);
        }

        private async Task<ICollection<EvaluationMethodModel>> GetAllEvaluationMethodModels()
        {
            var repository = new Repository<EvaluationMethod>(dbContext);
            var data = await repository.GetAll().ToListAsync();
            return mapper.Map<ICollection<EvaluationMethodModel>>(data);
        }

        private async Task<ICollection<MachineTypeModel>> GetAllMachineTypeModels()
        {
            var repository = new Repository<MachineType>(dbContext);
            var data = await repository.GetAll().ToListAsync();
            return mapper.Map<ICollection<MachineTypeModel>>(data);
        }

        private async Task<ICollection<NormModel>> GetAllNormModels()
        {
            var repository = new Repository<Norm>(dbContext);
            var data = await repository.GetAll().ToListAsync();
            return mapper.Map<ICollection<NormModel>>(data);
        }

        private async Task<ICollection<TypeOfFunctionModel>> GetAllTypeOfFunctionModels()
        {
            var repository = new Repository<TypeOfFunction>(dbContext);
            var data = await repository.GetAll().ToListAsync();
            return mapper.Map<ICollection<TypeOfFunctionModel>>(data);
        }

        private async Task<ICollection<TypeOfLogicModel>> GetAllTypeOfLogicModels()
        {
            var repository = new Repository<TypeOfLogic>(dbContext);
            var data = await repository.GetAll().ToListAsync();
            return mapper.Map<ICollection<TypeOfLogicModel>>(data);
        }

        private async Task<ICollection<TypeOfSubsystemModel>> GetAllTypeOfSubsystemModels()
        {
            var repository = new Repository<TypeOfSubsystem>(dbContext);
            var data = await repository.GetAll().ToListAsync();
            return mapper.Map<ICollection<TypeOfSubsystemModel>>(data);
        }

        private async Task<ICollection<CategoryModel>> GetAllCategoryModels()
        {
            var repository = new Repository<Category>(dbContext);
            var data = await repository.GetAll().ToListAsync();
            return mapper.Map<ICollection<CategoryModel>>(data);
        }

        private async Task<ICollection<FModel>> GetAllFModels()
        {
            var repository = new Repository<F>(dbContext);
            var data = await repository.GetAll().ToListAsync();
            return mapper.Map<ICollection<FModel>>(data);
        }

        private async Task<ICollection<MTTFdModel>> GetAllMTTFdModels()
        {
            var repository = new Repository<MTTFd>(dbContext);
            var data = await repository.GetAll().ToListAsync();
            return mapper.Map<ICollection<MTTFdModel>>(data);
        }

        private async Task<ICollection<PLModel>> GetAllPLModels()
        {
            var repository = new Repository<PerformanceLevel>(dbContext);
            var data = await repository.GetAll().ToListAsync();
            return mapper.Map<ICollection<PLModel>>(data);
        }

        private async Task<ICollection<PModel>> GetAllPModels()
        {
            var repository = new Repository<P>(dbContext);
            var data = await repository.GetAll().ToListAsync();
            return mapper.Map<ICollection<PModel>>(data);
        }

        private async Task<ICollection<SModel>> GetAllSModels()
        {
            var repository = new Repository<S>(dbContext);
            var data = await repository.GetAll().ToListAsync();
            return mapper.Map<ICollection<SModel>>(data);
        }

        private async Task<ICollection<ArchitectureModel>> GetAllArchitectureModels()
        {
            var repository = new Repository<Architecture>(dbContext);
            var data = await repository.GetAll().ToListAsync();
            return mapper.Map<ICollection<ArchitectureModel>>(data);
        }

        private async Task<ICollection<AvModel>> GetAllAvModels()
        {
            var repository = new Repository<Av>(dbContext);
            var data = await repository.GetAll().ToListAsync();
            return mapper.Map<ICollection<AvModel>>(data);
        }

        private async Task<ICollection<CFFModel>> GetAllCFFModels()
        {
            var repository = new Repository<CFF>(dbContext);
            var data = await repository.GetAll().ToListAsync();
            return mapper.Map<ICollection<CFFModel>>(data);
        }

        private async Task<ICollection<FrModel>> GetAllFrModels()
        {
            var repository = new Repository<Fr>(dbContext);
            var data = await repository.GetAll().ToListAsync();
            return mapper.Map<ICollection<FrModel>>(data);
        }

        private async Task<ICollection<PFHdModel>> GetAllPFHdModels()
        {
            var repository = new Repository<PFHd>(dbContext);
            var data = await repository.GetAll().ToListAsync();
            return mapper.Map<ICollection<PFHdModel>>(data);
        }

        private async Task<ICollection<PrModel>> GetAllPrModels()
        {
            var repository = new Repository<Pr>(dbContext);
            var data = await repository.GetAll().ToListAsync();
            return mapper.Map<ICollection<PrModel>>(data);
        }

        private async Task<ICollection<SeModel>> GetAllSeModels()
        {
            var repository = new Repository<Se>(dbContext);
            var data = await repository.GetAll().ToListAsync();
            return mapper.Map<ICollection<SeModel>>(data);
        }

        private async Task<ICollection<SFFModel>> GetAllSFFModels()
        {
            var repository = new Repository<SFF>(dbContext);
            var data = await repository.GetAll().ToListAsync();
            return mapper.Map<ICollection<SFFModel>>(data);
        }

        #endregion
    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SSEA.BL.Models;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using SSEA.DAL;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
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

        // TODO: add rest of methods

        #endregion
    }
}

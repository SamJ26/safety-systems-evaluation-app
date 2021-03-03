﻿using AutoMapper;
using SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels;
using SSEA.DAL;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SSEA.BL.Facades
{
    public class SafetyFunctionFacade : IExtendedFacade<SafetyFunctionDetailModelPL, SafetyFunctionDetailModelSIL, SafetyFunctionListModel, SafetyFunction>
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper mapper;

        public SafetyFunctionFacade(AppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public Task<int> CreateAsync(SafetyFunctionDetailModelPL newModel)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateAsync(SafetyFunctionDetailModelSIL newModel)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<SafetyFunctionListModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SafetyFunctionDetailModelPL> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SafetyFunctionDetailModelSIL> GetByIdAsync(int id, int temp = 0)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(SafetyFunctionDetailModelPL updatedModel)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(SafetyFunctionDetailModelSIL updatedModel)
        {
            throw new NotImplementedException();
        }
    }
}

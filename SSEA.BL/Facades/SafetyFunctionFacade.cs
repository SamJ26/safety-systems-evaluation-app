using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels;
using SSEA.DAL;
using SSEA.DAL.Entities.SafetyEvaluation.JoinEntities;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSEA.BL.Facades
{
    public class SafetyFunctionFacade
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper mapper;

        public SafetyFunctionFacade(AppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<ICollection<SafetyFunctionListModel>> GetAllAsync()
        {
            var data = await dbContext.SafetyFunctions.Include(sf => sf.CurrentState)
                                                      .Include(sf => sf.EvaluationMethod)
                                                      .Include(sf => sf.TypeOfFunction)
                                                      .AsNoTracking()
                                                      .ToListAsync();
            return mapper.Map<ICollection<SafetyFunctionListModel>>(data);
        }

        public async Task<ICollection<SafetyFunctionListModel>> GetAllAsync(int accessPointId)
        {
            // Getting all safety functions which are related to selected access point
            int[] safetyFunctions = await dbContext.AccessPointSafetyFunctions.Where(a => a.AccessPointId == accessPointId)
                                                                              .Select(a => a.AccessPointId)
                                                                              .ToArrayAsync();

            // Filtering safety functions according to id
            var data = await dbContext.SafetyFunctions.Include(sf => sf.CurrentState)
                                                      .Include(sf => sf.EvaluationMethod)
                                                      .Include(sf => sf.TypeOfFunction)
                                                      .Where(sf => safetyFunctions.Contains(sf.Id))
                                                      .ToListAsync();

            return mapper.Map<ICollection<SafetyFunctionListModel>>(data);
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

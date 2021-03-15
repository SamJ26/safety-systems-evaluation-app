using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels;
using SSEA.DAL;
using SSEA.DAL.Entities.SafetyEvaluation.JoinEntities;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using SSEA.DAL.Entities.System;
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

        private readonly int safetyFunctionNewStateId = 8;

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

        public async Task<int> CreateAsync(SafetyFunctionDetailModelPL newModel)
        {
            newModel.SafetyFunctionSubsystems.Clear();

            // Creating entity without collection
            var entity = mapper.Map<SafetyFunction>(newModel);

            // Assigning inital state to new record
            entity.CurrentState = await GetState(safetyFunctionNewStateId);

            dbContext.Attach(entity.TypeOfFunction).State = EntityState.Unchanged;
            dbContext.Attach(entity.EvaluationMethod).State = EntityState.Unchanged;
            dbContext.Attach(entity.PLr).State = EntityState.Unchanged;
            if (entity.S != null && entity.F != null && entity.P != null)
            {
                dbContext.Attach(entity.S).State = EntityState.Unchanged;
                dbContext.Attach(entity.F).State = EntityState.Unchanged;
                dbContext.Attach(entity.P).State = EntityState.Unchanged;
            }

            await dbContext.SafetyFunctions.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> CreateAsync(SafetyFunctionDetailModelSIL newModel)
        {
            newModel.SafetyFunctionSubsystems.Clear();

            // Creating entity without collection
            var entity = mapper.Map<SafetyFunction>(newModel);

            // Assigning inital state to new record
            entity.CurrentState = await GetState(safetyFunctionNewStateId);

            dbContext.Attach(entity.TypeOfFunction).State = EntityState.Unchanged;
            dbContext.Attach(entity.EvaluationMethod).State = EntityState.Unchanged;
            dbContext.Attach(entity.SILCL).State = EntityState.Unchanged;
            if (entity.Se != null && entity.Fr != null && entity.Pr != null && entity.Av != null)
            {
                dbContext.Attach(entity.Se).State = EntityState.Unchanged;
                dbContext.Attach(entity.Fr).State = EntityState.Unchanged;
                dbContext.Attach(entity.Pr).State = EntityState.Unchanged;
                dbContext.Attach(entity.Av).State = EntityState.Unchanged;
            }

            await dbContext.SafetyFunctions.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity.Id;
        }

        private async Task<State> GetState(int stateId)
        {
            return await dbContext.States.SingleOrDefaultAsync(s => s.Id == stateId);
        }
    }
}

﻿using Microsoft.EntityFrameworkCore;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSEA.DAL.Repositories
{
    public class SubsystemRepository
    {
        private readonly AppDbContext dbContext;

        private readonly int subsystemNewStateId = 14;
        private readonly int elementNewStateId = 15;

        public SubsystemRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ICollection<Subsystem>> GetAllPLAsync(int stateId, int typeOfSubsystemId, int operationPrincipleId, int categoryId, int performanceLevelId)
        {
            IQueryable<Subsystem> query = dbContext.Subsystems.Include(s => s.TypeOfSubsystem)
                                                              .Include(s => s.OperationPrinciple)
                                                              .Include(s => s.Category)
                                                              .Include(s => s.DCresult)
                                                              .Include(s => s.MTTFdResult)
                                                              .Include(s => s.PLresult)
                                                              .Include(s => s.CurrentState);
            if (stateId != 0)
                query = query.Where(s => s.CurrentStateId == stateId);
            if (typeOfSubsystemId != 0)
                query = query.Where(s => s.TypeOfSubsystemId == typeOfSubsystemId);
            if (operationPrincipleId != 0)
                query = query.Where(s => s.OperationPrincipleId == operationPrincipleId);
            if (categoryId != 0)
                query = query.Where(s => s.CategoryId == categoryId);
            if (performanceLevelId != 0)
                query = query.Where(s => s.PLresultId == performanceLevelId);
            return await query.ToListAsync();
        }

        public async Task<ICollection<Subsystem>> GetAllSILAsync(int stateId, int typeOfSubsystemId, int operationPrincipleId, int architectureId, int silId)
        {
            IQueryable<Subsystem> query = dbContext.Subsystems.Include(s => s.TypeOfSubsystem)
                                                              .Include(s => s.OperationPrinciple)
                                                              .Include(s => s.TypeOfSubsystem)
                                                              .Include(s => s.Architecture)
                                                              .Include(s => s.PFHdResult)
                                                              .Include(s => s.CurrentState);
            if (stateId != 0)
                query = query.Where(s => s.CurrentStateId == stateId);
            if (typeOfSubsystemId != 0)
                query = query.Where(s => s.TypeOfSubsystemId == typeOfSubsystemId);
            if (operationPrincipleId != 0)
                query = query.Where(s => s.OperationPrincipleId == operationPrincipleId);
            if (architectureId != 0)
                query = query.Where(s => s.ArchitectureId == architectureId);
            if (silId != 0)
                query = query.Where(s => s.PFHdResultId == silId);
            return await query.ToListAsync();
        }

        public async Task<Subsystem> GetByIdPLAsync(int id)
        {
            return await dbContext.Subsystems.Include(s => s.TypeOfSubsystem)
                                             .Include(s => s.OperationPrinciple)
                                             .Include(s => s.Category)
                                             .Include(s => s.DCresult)
                                             .Include(s => s.MTTFdResult)
                                             .Include(s => s.PLresult)
                                             .Include(s => s.CurrentState)
                                             .Include(s => s.Elements)
                                             .AsNoTracking()
                                             .SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Subsystem> GetByIdSILAsync(int id)
        {
            return await dbContext.Subsystems.Include(s => s.OperationPrinciple)
                                             .Include(s => s.TypeOfSubsystem)
                                             .Include(s => s.Architecture)
                                             .Include(s => s.PFHdResult)
                                             .Include(s => s.CFF)
                                             .Include(s => s.CurrentState)
                                             .Include(s => s.Elements)
                                             .AsNoTracking()
                                             .SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<ICollection<CCF>> GetCCFsForSubsystemAsync(int subsystemId)
        {
            // Getting all CCFs related to selected subsystem
            int[] foundIds = await dbContext.SubsystemCCFs.Where(a => a.SubsystemId == subsystemId)
                                                          .Select(a => a.CCFId)
                                                          .ToArrayAsync();
            ICollection<CCF> foundCCFs = new List<CCF>();
            if (foundIds.Count() != 0)
                foundCCFs = await dbContext.CCFs.Where(c => foundIds.Contains(c.Id)).ToListAsync();
            return foundCCFs;
        }

        // TODO
        public async Task<int> CreateAsync(Subsystem subsystem, int userId)
        {
            subsystem.CurrentStateId = subsystemNewStateId;

            dbContext.Attach(subsystem.TypeOfSubsystem).State = EntityState.Unchanged;
            dbContext.Attach(subsystem.OperationPrinciple).State = EntityState.Unchanged;

            subsystem.SafetyFunctionSubsystems = null;
            subsystem.SubsystemCCFs = null;

            // Setting navigation properties to avoid change tracking excpetion with trackig multiple entities with same id
            subsystem.DCresult = null;
            subsystem.Category = null;
            subsystem.MTTFdResult = null;
            subsystem.PLresult = null;
            subsystem.Architecture = null;
            subsystem.PFHdResult = null;
            foreach (var element in subsystem.Elements)
            {
                element.CurrentStateId = elementNewStateId;
                element.MTTFdResult = null;
                element.DC = null;
                element.Producer = null;
                element.Subsystem = null;
                element.ElementSFFs = null;
            }

            await dbContext.AddAsync(subsystem);
            await dbContext.CommitChangesAsync(userId);
            return subsystem.Id;
        }
    }
}

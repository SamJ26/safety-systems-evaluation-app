﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SSEA.BL.Facades
{
    public interface IFacade<TDetailModel, TListModel, TEntity>
    {
        Task<ICollection<TListModel>> GetAllAsync();
        Task<TDetailModel> GetByIdAsync(int id);
        Task<int> CreateAsync(TDetailModel newModel);
        Task<int> UpdateAsync(TDetailModel updatedModel);
        Task<int> DeleteAsync(int id);
    }
}

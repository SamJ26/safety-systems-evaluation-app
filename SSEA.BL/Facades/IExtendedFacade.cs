using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SSEA.BL.Facades
{
    public interface IExtendedFacade<TDetailModelPL, TDetailModelSIL, TListModel, TEntity>
    {
        Task<ICollection<TListModel>> GetAllAsync();
        Task<TDetailModelPL> GetByIdAsync(int id);
        Task<TDetailModelSIL> GetByIdAsync(int id, int temp = 0);
        Task<int> CreateAsync(TDetailModelPL newModel);
        Task<int> CreateAsync(TDetailModelSIL newModel);
        Task<int> UpdateAsync(TDetailModelPL updatedModel);
        Task<int> UpdateAsync(TDetailModelSIL updatedModel);
        Task<int> DeleteAsync(int id);
    }
}

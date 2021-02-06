using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.BL.Facades
{
    public interface IFacade<TDetailModel, TListModel>
    {
        IEnumerable<TListModel> GetAllAsync();
        TDetailModel GetByIdAsync();
        int CreateAsync(TDetailModel newModel);
        int UpdateAsync(TDetailModel updatedModel);
        void DeleteAsync(int Id);
    }
}

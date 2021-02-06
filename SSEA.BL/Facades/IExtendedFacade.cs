using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.BL.Facades
{
    public interface IExtendedFacade<TDetailModelPL, TDetailModelSIL, TListModel, TEntity>
    {
        IEnumerable<TListModel> GetAll();
        TDetailModelPL GetById();
        TDetailModelSIL GetById(int temp = 0);
        int Create(TDetailModelPL newModel);
        int Create(TDetailModelSIL newModel);
        int Update(TDetailModelPL updatedModel);
        int Update(TDetailModelSIL updatedModel);
        void Delete(int Id);
    }
}

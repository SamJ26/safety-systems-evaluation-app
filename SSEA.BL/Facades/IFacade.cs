using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.BL.Facades
{
    public interface IFacade<TDetailModel, TListModel, TEntity>
    {
        IEnumerable<TListModel> GetAll();
        TDetailModel GetById();
        int Create(TDetailModel newModel);
        int Update(TDetailModel updatedModel);
        void Delete(int Id);
    }
}

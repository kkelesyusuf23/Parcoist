using Parcoist.Business.Abstract;
using Parcoist.DataAccess.Abstract;
using Parcoist.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcoist.Business.Concrete
{
    public class ReturnItemManager : IReturnItemService
    {
        private readonly IReturnItemDal _returnItemDal;

        public ReturnItemManager(IReturnItemDal returnItemDal)
        {
            _returnItemDal = returnItemDal;
        }

        public void TAdd(ReturnItem entity)
        {
            _returnItemDal.Add(entity);
        }

        public void TDelete(ReturnItem entity)
        {
            _returnItemDal.Delete(entity);
        }

        public ReturnItem TGetById(int id)
        {
            return _returnItemDal.GetById(id);
        }

        public List<ReturnItem> TGetListAll()
        {
            return _returnItemDal.GetListAll();
        }

        public void TUpdate(ReturnItem entity)
        {
            _returnItemDal.Update(entity);
        }
    }
}

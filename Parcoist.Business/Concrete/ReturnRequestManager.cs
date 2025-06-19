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
    public class ReturnRequestManager : IReturnRequestService
    {
        private readonly IReturnRequestDal _returnRequestDal;

        public ReturnRequestManager(IReturnRequestDal returnRequestDal)
        {
            _returnRequestDal = returnRequestDal;
        }

        public void TAdd(ReturnRequest entity)
        {
            _returnRequestDal.Add(entity);
        }

        public void TDelete(ReturnRequest entity)
        {
            _returnRequestDal.Delete(entity);
        }

        public ReturnRequest TGetById(int id)
        {
            return _returnRequestDal.GetById(id);
        }

        public List<ReturnRequest> TGetListAll()
        {
            return _returnRequestDal.GetListAll();
        }

        public void TUpdate(ReturnRequest entity)
        {
            _returnRequestDal.Update(entity);
        }
    }
}

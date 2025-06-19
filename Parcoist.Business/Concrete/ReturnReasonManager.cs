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
    public class ReturnReasonManager : IReturnReasonService
    {
        private readonly IReturnReasonDal _returnReasonDal;

        public ReturnReasonManager(IReturnReasonDal returnReasonDal)
        {
            _returnReasonDal = returnReasonDal;
        }

        public void TAdd(ReturnReason entity)
        {
            _returnReasonDal.Add(entity);
        }

        public void TDelete(ReturnReason entity)
        {
            _returnReasonDal.Delete(entity);
        }

        public ReturnReason TGetById(int id)
        {
            return _returnReasonDal.GetById(id);
        }

        public List<ReturnReason> TGetListAll()
        {
            return _returnReasonDal.GetListAll();
        }

        public void TUpdate(ReturnReason entity)
        {
            _returnReasonDal.Update(entity);
        }
    }
}

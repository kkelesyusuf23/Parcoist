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
    public class ReturnStatusManager : IReturnStatusService
    {
        private readonly IReturnStatusDal _returnStatusDal;

        public ReturnStatusManager(IReturnStatusDal returnStatusDal)
        {
            _returnStatusDal = returnStatusDal;
        }

        public void TAdd(ReturnStatus entity)
        {
            _returnStatusDal.Add(entity);
        }

        public void TDelete(ReturnStatus entity)
        {
            _returnStatusDal.Delete(entity);
        }

        public ReturnStatus TGetById(int id)
        {
            return _returnStatusDal.GetById(id);
        }

        public List<ReturnStatus> TGetListAll()
        {
            return _returnStatusDal.GetListAll();
        }

        public void TUpdate(ReturnStatus entity)
        {
            _returnStatusDal.Update(entity);
        }
    }
}

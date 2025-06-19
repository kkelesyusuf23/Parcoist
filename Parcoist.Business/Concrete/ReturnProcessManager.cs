using Parcoist.Business.Abstract;
using Parcoist.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using Parcoist.UI.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcoist.Business.Concrete
{
    public class ReturnProcessManager : IReturnProcessService
    {
        private readonly IReturnProcessDal _returnProcessDal;

        public ReturnProcessManager(IReturnProcessDal returnProcessDal)
        {
            _returnProcessDal = returnProcessDal;
        }

        public void TAdd(ReturnProcess entity)
        {
            _returnProcessDal.Add(entity);
        }

        public void TDelete(ReturnProcess entity)
        {
            _returnProcessDal.Delete(entity);
        }

        public ReturnProcess TGetById(int id)
        {
            return _returnProcessDal.GetById(id);
        }

        public List<ReturnProcess> TGetListAll()
        {
            return _returnProcessDal.GetListAll();
        }

        public void TUpdate(ReturnProcess entity)
        {
            _returnProcessDal.Update(entity);
        }
    }
}

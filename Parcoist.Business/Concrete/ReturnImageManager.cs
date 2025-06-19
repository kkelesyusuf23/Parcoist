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
    public class ReturnImageManager : IReturnImageService
    {
        private readonly IReturnImageDal _returnImageDal;

        public ReturnImageManager(IReturnImageDal returnImageDal)
        {
            _returnImageDal = returnImageDal;
        }

        public void TAdd(ReturnImage entity)
        {
            _returnImageDal.Add(entity);
        }

        public void TDelete(ReturnImage entity)
        {
            _returnImageDal.Delete(entity);
        }

        public ReturnImage TGetById(int id)
        {
            return _returnImageDal.GetById(id);
        }

        public List<ReturnImage> TGetListAll()
        {
            return _returnImageDal.GetListAll();
        }

        public void TUpdate(ReturnImage entity)
        {
            _returnImageDal.Update(entity);
        }
    }
}

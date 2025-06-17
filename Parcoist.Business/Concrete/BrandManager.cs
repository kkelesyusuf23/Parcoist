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
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void TAdd(Brand entity)
        {
            _brandDal.Add(entity);
        }

        public void TDelete(Brand entity)
        {
            _brandDal.Delete(entity);
        }

        public Brand TGetById(int id)
        {
            return _brandDal.GetById(id);
        }

        public List<Brand> TGetListAll()
        {
            return _brandDal.GetListAll();
        }

        public void TUpdate(Brand entity)
        {
            _brandDal.Update(entity);   
        }
    }
}

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
    public class BrandCategoryManager: IBrandCategoryService
    {
        private readonly IBrandCategoryDal _brandCategoryDal;

        public BrandCategoryManager(IBrandCategoryDal brandCategoryDal)
        {
            _brandCategoryDal = brandCategoryDal;
        }

        public void TAdd(BrandCategory entity)
        {
            _brandCategoryDal.Add(entity);
        }

        public void TDelete(BrandCategory entity)
        {
            _brandCategoryDal.Delete(entity);
        }

        public BrandCategory TGetById(int id)
        {
            return _brandCategoryDal.GetById(id);
        }

        public List<BrandCategory> TGetListAll()
        {
            return _brandCategoryDal.GetListAll();
        }

        public void TUpdate(BrandCategory entity)
        {
            _brandCategoryDal.Update(entity);
        }
    }
}

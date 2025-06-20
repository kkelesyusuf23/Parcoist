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
    public class FeatureTypeCategoryManager : IFeatureTypeCategoryService
    {
        private readonly IFeatureTypeCategoryDal _featureTypeCategoryDal;

        public FeatureTypeCategoryManager(IFeatureTypeCategoryDal featureTypeCategoryDal)
        {
            _featureTypeCategoryDal = featureTypeCategoryDal;
        }

        public void TAdd(FeatureTypeCategory entity)
        {
            _featureTypeCategoryDal.Add(entity);
        }

        public void TDelete(FeatureTypeCategory entity)
        {
            _featureTypeCategoryDal.Delete(entity);
        }

        public FeatureTypeCategory TGetById(int id)
        {
            return _featureTypeCategoryDal.GetById(id);
        }

        public List<FeatureTypeCategory> TGetListAll()
        {
            return _featureTypeCategoryDal.GetListAll();
        }

        public void TUpdate(FeatureTypeCategory entity)
        {
            _featureTypeCategoryDal.Update(entity);
        }
    }
}

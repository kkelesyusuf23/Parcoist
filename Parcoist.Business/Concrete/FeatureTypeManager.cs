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
    public class FeatureTypeManager : IFeatureTypeService
    {
        private readonly IFeatureTypeDal _featureTypeDal;

        public FeatureTypeManager(IFeatureTypeDal featureTypeDal)
        {
            _featureTypeDal = featureTypeDal;
        }

        public void TAdd(FeatureType entity)
        {
            _featureTypeDal.Add(entity);
        }

        public void TDelete(FeatureType entity)
        {
            _featureTypeDal.Delete(entity);
        }

        public FeatureType TGetById(int id)
        {
            return _featureTypeDal.GetById(id);
        }

        public List<FeatureType> TGetListAll()
        {
            return _featureTypeDal.GetListAll();
        }

        public void TUpdate(FeatureType entity)
        {
            _featureTypeDal.Update(entity);
        }
    }
}

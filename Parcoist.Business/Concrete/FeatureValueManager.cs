using Parcoist.Business.Abstract;
using Parcoist.DataAccess.Abstract;
using Parcoist.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcoist.Business.Concrete
{
    public class FeatureValueManager:IFeatureValueService
    {
        private readonly IFeatureValueDal _featureValueDal;

        public FeatureValueManager(IFeatureValueDal featureValueDal)
        {
            _featureValueDal = featureValueDal;
        }

        public void TAdd(FeatureValue entity)
        {
            _featureValueDal.Add(entity);
        }

        public void TDelete(FeatureValue entity)
        {
            _featureValueDal.Delete(entity);
        }

        public FeatureValue TGetById(int id)
        {
            return _featureValueDal.GetById(id);
        }

        public List<FeatureValue> TGetListAll()
        {
            return _featureValueDal.GetListAll();
        }

        public void TUpdate(FeatureValue entity)
        {
            _featureValueDal.Update(entity);
        }
    }
}

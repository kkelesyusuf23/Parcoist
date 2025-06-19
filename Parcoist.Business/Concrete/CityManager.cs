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
    public class CityManager:ICityService
    {
        private readonly ICityDal _cityDal;

        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }

        public void TAdd(City entity)
        {
            _cityDal.Add(entity);
        }

        public void TDelete(City entity)
        {
            _cityDal.Delete(entity);
        }

        public City TGetById(int id)
        {
            return _cityDal.GetById(id);
        }

        public List<City> TGetListAll()
        {
            return _cityDal.GetListAll();
        }

        public void TUpdate(City entity)
        {
            _cityDal.Update(entity);
        }
    }
}

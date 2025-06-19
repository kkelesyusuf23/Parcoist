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
    public class DisctrictManager: IDisctrictService
    {
        private readonly IDistrictDal _disctrictDal;

        public DisctrictManager(IDistrictDal disctrictDal)
        {
            _disctrictDal = disctrictDal;
        }

        public void TAdd(Disctrict entity)
        {
            _disctrictDal.Add(entity);
        }

        public void TDelete(Disctrict entity)
        {
            _disctrictDal.Delete(entity);
        }

        public Disctrict TGetById(int id)
        {
            return _disctrictDal.GetById(id);
        }

        public List<Disctrict> TGetListAll()
        {
            return _disctrictDal.GetListAll();
        }

        public void TUpdate(Disctrict entity)
        {
            _disctrictDal.Update(entity);
        }
    }
}

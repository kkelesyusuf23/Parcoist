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
    public class AdressManager:IAdressService
    {
        private readonly IAdressDal _adressDal;

        public AdressManager(IAdressDal adressDal)
        {
            _adressDal = adressDal;
        }

        public void TAdd(Adress entity)
        {
            _adressDal.Add(entity);
        }

        public void TDelete(Adress entity)
        {
            _adressDal.Delete(entity);
        }

        public Adress TGetById(int id)
        {
            return _adressDal.GetById(id);
        }

        public List<Adress> TGetListAll()
        {
            return _adressDal.GetListAll();
        }

        public void TUpdate(Adress entity)
        {
            _adressDal.Update(entity);
        }
    }
}

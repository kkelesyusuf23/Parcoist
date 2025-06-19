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
    public class DeliveryManager:IDeliveryService
    {
        private readonly IDeliveryDal _deliveryDal;

        public DeliveryManager(IDeliveryDal deliveryDal)
        {
            _deliveryDal = deliveryDal;
        }

        public void TAdd(Delivery entity)
        {
            _deliveryDal.Add(entity);
        }

        public void TDelete(Delivery entity)
        {
            _deliveryDal.Delete(entity);
        }

        public Delivery TGetById(int id)
        {
            return _deliveryDal.GetById(id);
        }

        public List<Delivery> TGetListAll()
        {
            return _deliveryDal.GetListAll();
        }

        public void TUpdate(Delivery entity)
        {
            _deliveryDal.Update(entity);
        }
    }
}

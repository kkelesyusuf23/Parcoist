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
    public class DeliveryStatusManager : IDeliveryStatusService
    {
        private readonly IDeliveryStatusDal _deliveryStatusDal;

        public DeliveryStatusManager(IDeliveryStatusDal deliveryStatusDal)
        {
            _deliveryStatusDal = deliveryStatusDal;
        }

        public void TAdd(DeliveryStatus entity)
        {
            _deliveryStatusDal.Add(entity);
        }

        public void TDelete(DeliveryStatus entity)
        {
            _deliveryStatusDal.Delete(entity);  
        }

        public DeliveryStatus TGetById(int id)
        {
            return _deliveryStatusDal.GetById(id);
        }

        public List<DeliveryStatus> TGetListAll()
        {
            return _deliveryStatusDal.GetListAll();
        }

        public void TUpdate(DeliveryStatus entity)
        {
            _deliveryStatusDal.Update(entity);
        }
    }
}

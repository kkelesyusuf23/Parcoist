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
    public class OrderBrandStatusManager : IOrderBrandStatusService
    {
        private readonly IOrderBrandStatusDal _orderBrandStatusDal;

        public OrderBrandStatusManager(IOrderBrandStatusDal orderBrandStatusDal)
        {
            _orderBrandStatusDal = orderBrandStatusDal;
        }

        public void TAdd(OrderBrandStatus entity)
        {
            _orderBrandStatusDal.Add(entity);
        }

        public void TDelete(OrderBrandStatus entity)
        {
            _orderBrandStatusDal.Delete(entity);
        }

        public OrderBrandStatus TGetById(int id)
        {
            return _orderBrandStatusDal.GetById(id);
        }

        public List<OrderBrandStatus> TGetListAll()
        {
            return _orderBrandStatusDal.GetListAll();
        }

        public void TUpdate(OrderBrandStatus entity)
        {
            _orderBrandStatusDal.Update(entity);
        }
    }
}

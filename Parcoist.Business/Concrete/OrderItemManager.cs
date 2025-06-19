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
    public class OrderItemManager : IOrderItemService
    {
        private readonly IOrderItemDal _orderItemDal;

        public OrderItemManager(IOrderItemDal orderItemDal)
        {
            _orderItemDal = orderItemDal;
        }

        public void TAdd(OrderItem entity)
        {
            _orderItemDal.Add(entity);
        }

        public void TDelete(OrderItem entity)
        {
            _orderItemDal.Delete(entity);
        }

        public OrderItem TGetById(int id)
        {
            return _orderItemDal.GetById(id);
        }

        public List<OrderItem> TGetListAll()
        {
            return _orderItemDal.GetListAll();
        }

        public void TUpdate(OrderItem entity)
        {
            _orderItemDal.Update(entity);
        }
    }
}

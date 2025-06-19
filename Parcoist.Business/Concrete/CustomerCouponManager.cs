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
    public class CustomerCouponManager:ICustomerCouponService
    {
        private readonly ICustomerCouponDal _customerCouponDal;
        public CustomerCouponManager(ICustomerCouponDal customerCouponDal)
        {
            _customerCouponDal = customerCouponDal;
        }

        public void TAdd(CustomerCoupon entity)
        {
            _customerCouponDal.Add(entity);
        }

        public void TDelete(CustomerCoupon entity)
        {
            _customerCouponDal.Delete(entity);
        }

        public CustomerCoupon TGetById(int id)
        {
            return _customerCouponDal.GetById(id);
        }

        public List<CustomerCoupon> TGetListAll()
        {
            return _customerCouponDal.GetListAll();
        }

        public void TUpdate(CustomerCoupon entity)
        {
            _customerCouponDal.Update(entity);
        }
    }
}

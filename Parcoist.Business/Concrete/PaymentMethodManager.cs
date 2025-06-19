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
    public class PaymentMethodManager : IPaymentMethodService
    {
        private readonly IPaymentMethodDal _paymentMethodDal;

        public PaymentMethodManager(IPaymentMethodDal paymentMethodDal)
        {
            _paymentMethodDal = paymentMethodDal;
        }

        public void TAdd(PaymentMethod entity)
        {
            _paymentMethodDal.Add(entity);
        }

        public void TDelete(PaymentMethod entity)
        {
            _paymentMethodDal.Delete(entity);
        }

        public PaymentMethod TGetById(int id)
        {
            return _paymentMethodDal.GetById(id);
        }

        public List<PaymentMethod> TGetListAll()
        {
            return _paymentMethodDal.GetListAll();
        }

        public void TUpdate(PaymentMethod entity)
        {
            _paymentMethodDal.Update(entity);
        }
    }
}

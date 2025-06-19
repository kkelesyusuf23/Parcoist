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
    public class PaymentCardManager : IPaymentCardService
    {
        private readonly IPaymentCardDal _paymentCardDal;

        public PaymentCardManager(IPaymentCardDal paymentCardDal)
        {
            _paymentCardDal = paymentCardDal;
        }

        public void TAdd(PaymentCard entity)
        {
            _paymentCardDal.Add(entity);
        }

        public void TDelete(PaymentCard entity)
        {
            _paymentCardDal.Delete(entity);
        }

        public PaymentCard TGetById(int id)
        {
            return _paymentCardDal.GetById(id);
        }

        public List<PaymentCard> TGetListAll()
        {
            return _paymentCardDal.GetListAll();
        }

        public void TUpdate(PaymentCard entity)
        {
            _paymentCardDal.Update(entity);
        }
    }
}

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
    public class CustomerManager:ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public void TAdd(Customer entity)
        {
            _customerDal.Add(entity);
        }

        public void TDelete(Customer entity)
        {
            _customerDal.Delete(entity);
        }

        public Customer TGetById(int id)
        {
            return _customerDal.GetById(id);
        }

        public List<Customer> TGetListAll()
        {
            return _customerDal.GetListAll();
        }

        public void TUpdate(Customer entity)
        {
            _customerDal.Update(entity);
        }
    }
}

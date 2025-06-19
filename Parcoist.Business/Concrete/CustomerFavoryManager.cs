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
    public class CustomerFavoryManager : ICustomerFavoryService
    {
        private readonly ICustomerFavoryDal _customerFavoryDal;

        public CustomerFavoryManager(ICustomerFavoryDal customerFavoryDal)
        {
            _customerFavoryDal = customerFavoryDal;
        }

        public void TAdd(CustomerFavory entity)
        {
            _customerFavoryDal.Add(entity);
        }

        public void TDelete(CustomerFavory entity)
        {
            _customerFavoryDal.Delete(entity);
        }

        public CustomerFavory TGetById(int id)
        {
            return _customerFavoryDal.GetById(id);
        }

        public List<CustomerFavory> TGetListAll()
        {
            return _customerFavoryDal.GetListAll();
        }

        public void TUpdate(CustomerFavory entity)
        {
            _customerFavoryDal.Update(entity);
        }
    }
}

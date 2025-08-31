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
    public class UserManager:IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void TAdd(User entity)
        {
            _userDal.Add(entity);
        }

        public void TDelete(User entity)
        {
            _userDal.Delete(entity);
        }

        public User TGetById(int id)
        {
            return _userDal.GetById(id);
        }

        public List<User> TGetListAll()
        {
            return _userDal.GetListAll();
        }

        public void TUpdate(User entity)
        {
            _userDal.Update(entity);
        }
    }
}

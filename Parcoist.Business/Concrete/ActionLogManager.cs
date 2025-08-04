using Parcoist.Business.Abstract;
using Parcoist.DataAccess.Abstract;
using Parcoist.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcoist.Business.Concrete
{
    public class ActionLogManager : IActionLogService
    {
        private readonly IActionLogDal _actionLogDal;

        public ActionLogManager(IActionLogDal actionLogDal)
        {
            _actionLogDal = actionLogDal;
        }

        public void TAdd(ActionLog entity)
        {
            _actionLogDal.Add(entity);
        }

        public void TDelete(ActionLog entity)
        {
            _actionLogDal.Delete(entity);
        }

        public ActionLog TGetById(int id)
        {
            return _actionLogDal.GetById(id);
        }

        public List<ActionLog> TGetListAll()
        {
            return _actionLogDal.GetListAll();
        }

        public void TUpdate(ActionLog entity)
        {
            _actionLogDal.Update(entity);
        }
    }
}

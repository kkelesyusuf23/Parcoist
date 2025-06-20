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
    public class LogoManager:ILogoService
    {
        private readonly ILogoDal _logoDal;

        public LogoManager(ILogoDal logoDal)
        {
            _logoDal = logoDal;
        }

        public void TAdd(Logo entity)
        {
            _logoDal.Add(entity);
        }

        public void TDelete(Logo entity)
        {
            _logoDal.Delete(entity);
        }

        public Logo TGetById(int id)
        {
            return _logoDal.GetById(id);
        }

        public List<Logo> TGetListAll()
        {
            return _logoDal.GetListAll();
        }

        public void TUpdate(Logo entity)
        {
            _logoDal.Update(entity);
        }
    }
}

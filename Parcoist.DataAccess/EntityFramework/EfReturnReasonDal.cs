using Parcoist.DataAccess.Abstract;
using Parcoist.DataAccess.Concrete;
using Parcoist.DataAccess.Repositories;
using Parcoist.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcoist.DataAccess.EntityFramework
{
    public class EfReturnReasonDal : GenericRepository<ReturnReason>, IReturnReasonDal
    {
        public EfReturnReasonDal(ParcoContext context) : base(context)
        {
        }
    }
}

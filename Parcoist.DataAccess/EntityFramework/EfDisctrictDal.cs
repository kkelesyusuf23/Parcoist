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
    public class EfDisctrictDal : GenericRepository<Disctrict>, IDistrictDal
    {
        public EfDisctrictDal(ParcoContext context) : base(context)
        {
        }
    }
}

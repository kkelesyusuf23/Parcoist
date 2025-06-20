using Parcoist.DataAccess.Abstract;
using Parcoist.DataAccess.Concrete;
using Parcoist.DataAccess.Repositories;
using Parcoist.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcoist.DataAccess.EntityFramework
{
    public class EfSliderDal : GenericRepository<Slider>, ISliderDal
    {
        public EfSliderDal(ParcoContext context) : base(context)
        {
        }
    }
}

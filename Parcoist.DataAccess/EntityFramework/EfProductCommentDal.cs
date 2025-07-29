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
    public class EfProductCommentDal : GenericRepository<ProductComment>, IProductCommentDal
    {
        public EfProductCommentDal(ParcoContext context) : base(context)
        {
        }
    }
}

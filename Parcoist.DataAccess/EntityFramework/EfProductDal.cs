using Microsoft.EntityFrameworkCore;
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
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        private readonly ParcoContext _context;

        public EfProductDal(ParcoContext context) : base(context)
        {
            _context = context;
        }

        public List<Product> GetProductsWithAllRelations()
        {
            return _context.Products
                .Include(p => p.ProductImages)
                .Include(p => p.CustomerFavorites)
                .Include(p => p.OrderItems)
                .Include(p => p.UserComments)
                .Include(p => p.Brand)
                .ToList();
        }



    }
}

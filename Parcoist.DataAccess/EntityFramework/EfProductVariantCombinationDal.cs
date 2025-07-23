using Microsoft.EntityFrameworkCore;
using Parcoist.DataAccess.Abstract;
using Parcoist.DataAccess.Concrete;
using Parcoist.DataAccess.Repositories;
using Parcoist.Entity.Concrete;
using Parcoist.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcoist.DataAccess.EntityFramework
{
    public class EfProductVariantCombinationDal : GenericRepository<ProductVariantCombination>, IProductVariantCombinationDal
    {
        private readonly ParcoContext _context;
        public EfProductVariantCombinationDal(ParcoContext context) : base(context)
        {
            _context = context;
        }

        public List<ProductVariantCombination> GetProductVariantWithProductAndValues()
        {
            return _context.ProductVariantCombinations
                .Include(p => p.Product)
                .Include(p => p.ProductVariantValues)
                .ToList();
        }
    }
}

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

        public List<ProductVariantCombination> GetProductVariantWithProductAndValues(int productId)
        {
            return _context.ProductVariantCombinations
                .Where(vc => vc.ProductID == productId)
                .Include(vc => vc.ProductVariantValues)
                    .ThenInclude(pvv => pvv.FeatureType)
                .Include(vc => vc.ProductVariantValues)
                    .ThenInclude(pvv => pvv.FeatureValue)
                .ToList();
        }
    }
}
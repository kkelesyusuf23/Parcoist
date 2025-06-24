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
    public class ProductVariantCombinationManager : IProductVariantCombinationService
    {
        private readonly IProductVariantCombinationDal _productVariantCombinationDal;

        public ProductVariantCombinationManager(IProductVariantCombinationDal productVariantCombinationDal)
        {
            _productVariantCombinationDal = productVariantCombinationDal;
        }

        public void TAdd(ProductVariantCombination entity)
        {
            _productVariantCombinationDal.Add(entity);
        }

        public void TDelete(ProductVariantCombination entity)
        {
            _productVariantCombinationDal.Delete(entity);
        }

        public ProductVariantCombination TGetById(int id)
        {
            return _productVariantCombinationDal.GetById(id);
        }

        public List<ProductVariantCombination> TGetListAll()
        {
            return _productVariantCombinationDal.GetListAll();
        }

        public void TUpdate(ProductVariantCombination entity)
        {
            _productVariantCombinationDal.Update(entity);
        }
    }
}

using Parcoist.Business.Abstract;
using Parcoist.DataAccess.Abstract;
using Parcoist.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcoist.Business.Concrete
{
    public class ProductVariantValueManager : IProductVariantValueService
    {
        private readonly IProductVariantValueDal _productVariantValueDal;

        public ProductVariantValueManager(IProductVariantValueDal productVariantValueDal)
        {
            _productVariantValueDal = productVariantValueDal;
        }

        public void TAdd(ProductVariantValue entity)
        {
            _productVariantValueDal.Add(entity);
        }

        public void TDelete(ProductVariantValue entity)
        {
            _productVariantValueDal.Delete(entity);
        }

        public ProductVariantValue TGetById(int id)
        {
            return _productVariantValueDal.GetById(id);
        }

        public List<ProductVariantValue> TGetListAll()
        {
            return _productVariantValueDal.GetListAll();
        }

        public void TUpdate(ProductVariantValue entity)
        {
            _productVariantValueDal.Update(entity);
        }
    }
}

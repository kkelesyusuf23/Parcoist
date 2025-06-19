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
    public class ProductImageManager:IProductImageService
    {
        private readonly IProductImageDal _productImageDal;

        public ProductImageManager(IProductImageDal productImageDal)
        {
            _productImageDal = productImageDal;
        }

        public void TAdd(ProductImage entity)
        {
            _productImageDal.Add(entity);
        }

        public void TDelete(ProductImage entity)
        {
            _productImageDal.Delete(entity);
        }

        public ProductImage TGetById(int id)
        {
            return _productImageDal.GetById(id);
        }

        public List<ProductImage> TGetListAll()
        {
            return _productImageDal.GetListAll();
        }

        public void TUpdate(ProductImage entity)
        {
            _productImageDal.Update(entity);
        }
    }
}

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
    public class ProductCommentManager:IProductCommentService
    {
        private readonly IProductCommentDal _productCommentDal;

        public ProductCommentManager(IProductCommentDal productCommentDal)
        {
            _productCommentDal = productCommentDal;
        }

        public void TAdd(ProductComment entity)
        {
            _productCommentDal.Add(entity);
        }

        public void TDelete(ProductComment entity)
        {
            _productCommentDal.Delete(entity);
        }

        public ProductComment TGetById(int id)
        {
            return _productCommentDal.GetById(id);
        }

        public List<ProductComment> TGetListAll()
        {
            return _productCommentDal.GetListAll();
        }

        public void TUpdate(ProductComment entity)
        {
            _productCommentDal.Update(entity);
        }
    }
}

using Parcoist.UI.Entities;

namespace Parcoist.UI.Models
{
    public class CategoryWithProductsViewModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public List<Product> Products { get; set; }
    }

}

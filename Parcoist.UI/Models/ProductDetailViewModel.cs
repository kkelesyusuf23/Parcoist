using Parcoist.Entity.Concrete;
using Parcoist.UI.Entities;

public class ProductDetailViewModel
{
    public Product? Product { get; set; }
    public List<ProductImage>? ProductImages { get; set; }
    public List<ProductVariantCombination>? VariantCombinations { get; set; }
    public List<ProductComment>? ProductComments { get; set; } // Yorumlar
}

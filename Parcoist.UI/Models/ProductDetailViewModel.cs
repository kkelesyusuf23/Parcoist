using Parcoist.Entity.Concrete;
using Parcoist.UI.Entities;

// Dosya: ViewModels/ProductDetailViewModel.cs
public class ProductDetailViewModel
{
    public Product Product { get; set; }
    public List<ProductImage> ProductImages { get; set; }
    public List<ProductVariantCombination> VariantCombinations { get; set; }
}



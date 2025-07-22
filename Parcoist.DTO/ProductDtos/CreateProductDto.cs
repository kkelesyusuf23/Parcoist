using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcoist.DTO.ProductDtos
{
    public class CreateProductDto
    {
        public int SKU { get; set; }
        public string ModelNo { get; set; }
        public string Name { get; set; }
        public int CategoryID { get; set; }
        public decimal BasePrice { get; set; }
        public decimal CostPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public string? Link1 { get; set; }
        public string? Link2 { get; set; }
        public string? Link3 { get; set; }
        public bool IsFeatured { get; set; }
        public int BrandID { get; set; }
    }
}

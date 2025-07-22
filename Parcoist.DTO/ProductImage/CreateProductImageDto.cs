using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcoist.DTO.ProductImage
{
    public class CreateProductImageDto
    {
        public int ProductID { get; set; }
        public string ImagePath { get; set; }
        public string Order { get; set; } 
    }
}

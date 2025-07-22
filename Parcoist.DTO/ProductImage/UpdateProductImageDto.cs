using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcoist.DTO.ProductImage
{
    public class UpdateProductImageDto
    {
        public int ProductImageID { get; set; }

        public int ProductID { get; set; }
        public string ImagePath { get; set; }
        public string Order { get; set; }
    }
}

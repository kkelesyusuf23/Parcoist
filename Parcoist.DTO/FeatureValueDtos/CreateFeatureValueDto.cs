using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcoist.DTO.FeatureValueDtos
{
    public class CreateFeatureValueDto
    {
        public int FeatureTypeID { get; set; } 
        public string Value { get; set; }
        public int PriceAdjustment { get; set; }
        public int Stock { get; set; } 
    }
}

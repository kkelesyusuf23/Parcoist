using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcoist.DTO.FeatureTypeDtos
{
    public class UpdateFeatureTypeDto
    {
        public int FeatureTypeID { get; set; }
        public string Value { get; set; }
        public int PriceAdjustment { get; set; } 
    }
}

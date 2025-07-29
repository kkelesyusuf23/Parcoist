using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcoist.Entity.Concrete
{
    public class Slider
    {
        public int SliderID { get; set; }
        public string SliderTitle { get; set; }
        public string SliderImage { get; set; }
        public string SliderLink { get; set; }
        public string SliderLinkTitle { get; set; }
        public string SliderDescription { get; set; }
        public bool SliderStatus { get; set; }
        public int SliderOrder { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
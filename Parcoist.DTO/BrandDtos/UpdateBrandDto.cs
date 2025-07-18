using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcoist.DTO.BrandDtos
{
    public class UpdateBrandDto
    {
        public int BrandID { get; set; }
        public string Name { get; set; }
        public string LogoURL { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
}

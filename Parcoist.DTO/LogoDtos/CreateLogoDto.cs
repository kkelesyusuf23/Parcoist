using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcoist.DTO.LogoDtos
{
    public class CreateLogoDto
    {
        public string LogoImage { get; set; }
        public string LogoTitle { get; set; }
        public string LogoLink { get; set; }
    }
}

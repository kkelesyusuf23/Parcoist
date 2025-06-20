using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcoist.Entity.Concrete
{
    public class Logo
    {
        public int LogoID { get; set; }
        public string LogoImage { get; set; }
        public string LogoTitle { get; set; }
        public string LogoLink { get; set; }
        public DateTime LogoDate { get; set; }
        public bool LogoStatus { get; set; }
    }
}

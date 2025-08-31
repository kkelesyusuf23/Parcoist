using Parcoist.UI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcoist.Entity.Concrete
{
    public class ActionLog
    {
        public int ActionLogID { get; set; }
        public int? UserID { get; set; } 
        public string ActionType { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}

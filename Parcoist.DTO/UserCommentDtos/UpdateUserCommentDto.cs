using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcoist.DTO.UserCommentDtos
{
    public class UpdateUserCommentDto
    {
        public int UserCommentID { get; set; }
        public string username { get; set; }
        public int ProductID { get; set; }
        public string Comment { get; set; }
        public string Description { get; set; } // Başlık gibi düşünülebilir
    }
}

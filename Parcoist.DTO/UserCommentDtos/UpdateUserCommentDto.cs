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
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public string Comment { get; set; }
        public string Description { get; set; } // Başlık gibi düşünülebilir
    }
}

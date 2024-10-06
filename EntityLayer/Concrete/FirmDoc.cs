using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class FirmDoc
    {
        [Key]
        public int ImgID { get; set; }
      
        public byte[] IMGData { get; set; }
    
        [ForeignKey("ID")]
        public int ContentID { get; set; }
        public Content Content { get; set; }
        public string URL { get; set; }
        public int UserID { get; set; }
    }
}


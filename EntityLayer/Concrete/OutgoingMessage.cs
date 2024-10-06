using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class OutgoingMessage
    {
        [Key]
        public int ID { get; set; }
        public int CID { get; set; }
        public int UserID { get; set; }
        public string SenderName { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int Status { get; set; }
    }
}

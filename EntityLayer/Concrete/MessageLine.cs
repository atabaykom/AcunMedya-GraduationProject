using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class MessageLine
    {
        public int ID { get; set; }
        public int MREF { get; set; }
        public int SenderUserID { get; set; }
        public int ReceiverUserID { get; set; }
        public string Content { get; set; }
        public int Status { get; set; }
        public DateTime Date_ { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Notification
    {
        [Key]
        public int EmailQueueID { get; set; }
        public string ToAdress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public int Status { get; set; }
        public int RetryCount { get; set; }
        public int LastRetryDate { get; set; }
        public bool IsDelivered { get; set; }
    }
}

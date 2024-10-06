using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Testimonial
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }
    }
}

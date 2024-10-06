using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class MessageRef
    {
        [Key]
        public int MID { get; set; }
        public int CREF { get; set; }
    }
}

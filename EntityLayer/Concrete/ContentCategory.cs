using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ContentCategory
    {
        [Key]
        public int CATEGORYID { get; set; }
        public string CATNAME { get; set; }
        public bool ISACTIVE { get; set; }
    }
}

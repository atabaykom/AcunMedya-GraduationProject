using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ContentInteraction
    {
        [Key]
        public int InteractionID { get; set; }
        [ForeignKey("ID")]
        public int ContentID { get; set; }
        public Content Content { get; set; }
        public int ViewCount { get; set; }
        public int FavoriteCount { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ContentFavoriteMap
    {
        [Key]
        public int MapId { get; set; }

        [ForeignKey("Contents")]
        public int ContentID { get; set; }
        public Content Content { get; set; }

        [ForeignKey("AppUser")]
        public int UserID { get; set; }
        public AppUser AppUser { get; set; }
    }

}

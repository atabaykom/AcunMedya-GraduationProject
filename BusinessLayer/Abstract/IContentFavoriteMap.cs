using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentFavoriteMap:IGenericService<ContentFavoriteMap>
    {
        List<ContentFavoriteMap> GetFavoriteListByUserID(int userID);
    }
}

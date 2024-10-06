using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContentFavoriteMapManager : IContentFavoriteMap
    {
        IContentFavoriteMapDal _contentFavoriteMap;

        public ContentFavoriteMapManager(IContentFavoriteMapDal contentFavoriteMap)
        {
            _contentFavoriteMap = contentFavoriteMap;
        }

        public List<ContentFavoriteMap> GetFavoriteListByUserID(int userID)
        {
            var mapList = _contentFavoriteMap.GetList().Where(x => x.UserID==userID).ToList();
            return mapList;
        }
        public void TAdd(ContentFavoriteMap t)
        {
            var count = _contentFavoriteMap.GetList().Where(x => x.ContentID == t.ContentID && x.UserID == t.UserID).ToList();
            if (count.Count<1)
            {
                _contentFavoriteMap.Insert(t);
            }
         
        }

        public void TDelete(ContentFavoriteMap t)
        {
            _contentFavoriteMap.Delete(t);
        }

        public ContentFavoriteMap TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<ContentFavoriteMap> TGetList()
        {
           return _contentFavoriteMap.GetList();
        }

        public List<ContentFavoriteMap> TGetListByFilter()
        { throw new NotImplementedException();
        }

        public void TUpdate(ContentFavoriteMap t)
        {
            throw new NotImplementedException();
        }
    }
}

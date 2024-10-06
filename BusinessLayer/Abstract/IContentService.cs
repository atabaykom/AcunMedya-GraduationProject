using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService:IGenericService<Content>
    {
        List<Content> GetFeaturedAdList(int count);
		List<Content> GetAdListByStatu(bool p);
        List<Content> GetAdListByUser(int userId);
        Task<List<Content>> GetAdListByUserWithStatu(int userId,bool p);
        Task<List<Content>> GetAdCountByCategory(int categoryID);
        List<Content> GetUserFavoriteList(int[] ads);
        List<Content> GetContentByFilter(Content content, int? minPrice, int? maxPrice, int? minm2, int? maxm2, int? maxDues, int? minDues);
    }
}

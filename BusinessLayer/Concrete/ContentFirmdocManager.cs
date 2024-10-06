using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContentFirmdocManager
    {
        private readonly IGenericDal<Content> _contentDal;
        private readonly IGenericDal<FirmDoc> _firmDoc;
        private readonly IGenericDal<ContentFavoriteMap> _favorite;

		public ContentFirmdocManager(IGenericDal<Content> contentDal, IGenericDal<FirmDoc> firmDoc, IGenericDal<ContentFavoriteMap>? favorite=null)
        {
            _contentDal = contentDal;
            _firmDoc = firmDoc;
            _favorite = favorite;
        }

        public class ContentFirmDocViewModel
        {
            public Content Content { get; set; }
            public ContentFavoriteMap ContentFavoriteMap { get; set; }
            public string URL { get; set; }
        }
        public List<ContentFirmDocViewModel> GetAdListWithIMG()
        {
            var contentList = _contentDal.GetList();
            var imgList = _firmDoc.GetList();
            var result = from content in contentList
                         join img in imgList
                         on content.ID equals img.ContentID into joined
                         from img in joined.DefaultIfEmpty()
                         group new { content, img } by content.ID into grouped
                         select new ContentFirmDocViewModel
                         {
                             Content = _contentDal.GetByID(grouped.Key),
                             URL = grouped.Select(x => x.img).FirstOrDefault() != null ? grouped.Select(x => x.img).FirstOrDefault().URL : "/img/NoIMG.jpg"
                         };
            return result.ToList();
        }
        public List<ContentFirmDocViewModel> GetAdListWithIMGByStatu(bool p)
        {
            var contentList = _contentDal.GetByFilter(x => x.IsActive == p);
            var imgList = _firmDoc.GetList();
            var result = from content in contentList
                         join img in imgList
                         on content.ID equals img.ContentID into joined
                         from img in joined.DefaultIfEmpty()
                         group new { content, img } by content.ID into grouped
                         select new ContentFirmDocViewModel
                         {
                             Content = _contentDal.GetByID(grouped.Key),
                             URL = grouped.Select(x => x.img).FirstOrDefault() != null ? grouped.Select(x => x.img).FirstOrDefault().URL : "/img/NoIMG.jpg"
                         };
            return result.ToList();
        }
		public List<ContentFirmDocViewModel> GetAdListWithIMGByUser(int userID)
		{
			var contentList = _contentDal.GetByFilter(x=>x.ContentOwnerID == userID);
			var imgList = _firmDoc.GetList();
			var result = from content in contentList
						 join img in imgList
						 on content.ID equals img.ContentID into joined
						 from img in joined.DefaultIfEmpty()
                         group new {content, img} by content.ID into grouped
						 select new ContentFirmDocViewModel
						 {
							 Content = _contentDal.GetByID(grouped.Key),
							 URL = grouped.Select(x=>x.img).FirstOrDefault() !=null? grouped.Select(x=>x.img).FirstOrDefault().URL : "/img/NoIMG.jpg"
						 };
			return result.ToList();
		}
		public List<ContentFirmDocViewModel> GetFavoriteListWithIMGByUser(int userID)
		{
			var contentList = _favorite.GetList().Where(x => x.UserID == userID).ToList();
			var imgList = _firmDoc.GetList();
			var result = from content in contentList
						 join img in imgList
						 on content.ContentID equals img.ContentID into joined
						 from img in joined.DefaultIfEmpty()
						 group new { content, img } by content.ContentID into grouped
						 select new ContentFirmDocViewModel
						 {
							 Content = _contentDal.GetByID(grouped.Key),
							 URL = grouped.Select(x => x.img).FirstOrDefault() != null ? grouped.Select(x => x.img).FirstOrDefault().URL : "/img/NoIMG.jpg"
						 };
			return result.ToList();
		}
      
    }
}

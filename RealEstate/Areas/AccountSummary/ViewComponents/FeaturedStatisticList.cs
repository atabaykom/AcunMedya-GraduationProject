using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace RealEstate.Areas.AccountSummary.ViewComponents
{
    public class FeatureStatisticsList : ViewComponent
    {
        ContentManager _contentManager = new ContentManager(new EfContentDal());
        ContentFavoriteMapManager _contentFavoriteManager = new ContentFavoriteMapManager(new EfContentFavoriteMapDal());
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string cookieuserID;
            if (Request.Cookies.TryGetValue("MANREF",out cookieuserID) !=null)
            {
                if (int.TryParse(cookieuserID,out int userID))
                {
                    var LiveAdCount =  (await _contentManager.GetAdListByUserWithStatu(userID,true)).Count;
                    var NonLiveAdCount = (await _contentManager.GetAdListByUserWithStatu(userID, false)).Count;
                    var FavoriteAdCounut = _contentFavoriteManager.GetFavoriteListByUserID(userID).Count;
                    ViewBag.LiveAdCount = LiveAdCount;
                    ViewBag.NonLiveAdCount = NonLiveAdCount;
                    ViewBag.FavoriteAdCount = FavoriteAdCounut;
                    return View();
                }
            }
            return View();
        }
    }
}

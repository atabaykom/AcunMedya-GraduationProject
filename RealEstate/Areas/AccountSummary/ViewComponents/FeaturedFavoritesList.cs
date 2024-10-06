using AutoMapper;
using BusinessLayer.Concrete;
using DataAccesLayer.Abstract;
using DataAccesLayer.EntityFramework;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.ViewModels;
using System.Runtime.CompilerServices;
using System.Security.Claims;

public class FeaturedFavoritesList : ViewComponent
{
    private readonly IMapper _mapper;
    private readonly UserManager<AppUser> _userManager;
    private readonly ContentManager _contentManager;
    private readonly ContentFirmdocManager _contentFirmdocManager;

    public FeaturedFavoritesList(UserManager<AppUser> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _contentManager = new ContentManager(new EfContentDal(), userManager);
        _contentFirmdocManager = new ContentFirmdocManager(new EfContentDal(), new EfFirmDocDal(), new EfContentFavoriteMapDal());
        _mapper = mapper;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var cookieUserID = HttpContext.Request.Cookies["MANREF"];
        if (int.TryParse(cookieUserID, out int userID))
        {
            var userContentMap = _contentFirmdocManager.GetFavoriteListWithIMGByUser(userID);
            var contentsID = userContentMap.Select(x => x.Content.ID).ToArray();
            var FavoriteList = _contentManager.GetUserFavoriteList(contentsID);

            var mapList = userContentMap.Select(item =>
            {
                var contentViewModel = _mapper.Map<ContentViewModel>(item.Content);
                contentViewModel.firmDocs = new List<FirmDoc>();
                contentViewModel.firmDocs.Add(new FirmDoc { URL = item.URL });
                return contentViewModel;
            }).ToList();
            return View(mapList);
        }
        return View();
    }
}

using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstate.ViewModels;
using System.Diagnostics;
using static BusinessLayer.Concrete.ContentFirmdocManager;

namespace RealEstate.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseController
    {
        public HomeController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IEmailSender emailSender, AccountManager accountManager, IMapper mapper, RoleManager<AppRole> roleManager, IUrlHelper urlHelper, IHttpContextAccessor httpContextAccessor, ContentManager contentManager, ContentCategoryManager contentCategoryManager, InComingMessageManager incomingMessageManager, OutGoingMessageManager outgoingMessagesManager, ContentFirmdocManager contentFirmdocManager, AccountManager user, MessageLineManager messageLineManager, ContentFavoriteMapManager contentFavoriteMapManager) : base(signInManager, userManager, emailSender, accountManager, mapper, roleManager, urlHelper, httpContextAccessor, contentManager, contentCategoryManager, incomingMessageManager, outgoingMessagesManager, contentFirmdocManager, user, messageLineManager, contentFavoriteMapManager)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AdList(FilterViewModel filter)
        {
            IQueryable<Content> filteredList = null;
            if (filter.CategoryName!=null){
            filter.CategoryID = _contentCategoryManager.GetCategoryID(filter.CategoryName).Result.CATEGORYID;
            }
            bool isNull = filter.GetType().GetProperties().Any(x => x.GetValue(filter) != null);
            if (isNull != false)
            {
                var map = _mapper.Map<Content>(filter);
                filteredList = _contentManager.GetContentByFilter(map, filter.priceMin, filter.priceMax, filter.minm2, filter.maxm2, filter.maxDues, filter.minDues).AsQueryable();
            }
            var adList = _contentFirmdocManager.GetAdListWithIMGByStatu(true)
           .Where(x => filteredList == null || filteredList.Select(y => y.ID).Contains(x.Content.ID))
           .Select(item => new ContentFirmDocViewModel { Content = item.Content, URL = item.URL })
           .ToList();
            return View("AdList", adList);
        }
        public async Task<IActionResult> GetAdDetail(int id)
        {
            if (id != null)
            {
                FirmDocManager firmdoc = new FirmDocManager(new EfFirmDocDal());
                var content = _contentManager.TGetByID(id);
                var IMGList = firmdoc.GetAdIMG(id).ToList();
                var map = _mapper.Map<ContentViewModel>(content);
                if (IMGList.Count > 0)
                {
                    map.firmDocs = IMGList;
                }
                else if (IMGList.Count == 0)
                {
                    map.firmDocs = new List<FirmDoc>();
                    map.firmDocs.Add(new FirmDoc { URL = "/img/NoIMG.jpg" });
                }
                var mapList = new List<ContentViewModel> { map };
                return View(mapList);
            }
            return View();
        }
    }
}

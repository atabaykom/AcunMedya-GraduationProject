using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Areas.AccountSummary.Models;
using RealEstate.Controllers;
using RealEstate.ViewModels;
namespace RealEstate.Areas.AccountSummary.Controllers
{
    [Area("AccountSummary")]
    [Authorize]
    public class OverviewController : BaseController
    {
        public OverviewController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, BusinessLayer.Abstract.IEmailSender emailSender, AccountManager accountManager, IMapper mapper, RoleManager<AppRole> roleManager, IUrlHelper urlHelper, IHttpContextAccessor httpContextAccessor, ContentManager contentManager, ContentCategoryManager contentCategoryManager, InComingMessageManager incomingMessageManager, OutGoingMessageManager outgoingMessagesManager, ContentFirmdocManager contentFirmdocManager, AccountManager user, MessageLineManager messageLineManager, ContentFavoriteMapManager contentFavoriteMapManager) : base(signInManager, userManager, emailSender, accountManager, mapper, roleManager, urlHelper, httpContextAccessor, contentManager, contentCategoryManager, incomingMessageManager, outgoingMessagesManager, contentFirmdocManager, user, messageLineManager, contentFavoriteMapManager)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByIdAsync(CookieDegeri("MANREF").ToString());
            ViewBag.v1 = user.Name;
            ViewBag.v2 = user.Surname;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel model, IFormFile ProfilePicture)
        {
            var user = await _userManager.FindByIdAsync(CookieDegeri("MANREF"));
            if (ModelState.IsValid && user!=null)
            {
                if (ProfilePicture != null)
                {
                    string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/userimg/" + CookieDegeri("MANREF")+".jpg");
                    using (var stream = new FileStream(uploadPath, FileMode.Create))
                    {
                        await ProfilePicture.CopyToAsync(stream);
                    }
                    string url = "/img/userimg/" + CookieDegeri("MANREF") + ".jpg";
                    user.IMGURL = url;
                }
                user.Name = model.Name;
                user.Surname = model.Surname;
                IdentityResult IdentityResult = await _userManager.UpdateAsync(user);
                if (!IdentityResult.Succeeded)
                {
                    IdentityResult.Errors.ToList().ForEach(e => ModelState.AddModelError(e.Code, e.Description));
                    return View(model);
                }
                if (await _userManager.CheckPasswordAsync(user, model.OldPassword))
                {
                    IdentityResult result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    if (!result.Succeeded)
                    {
                        result.Errors.ToList().ForEach(e => ModelState.AddModelError(e.Code, e.Description));
                        return View(model);
                    }
                }
                await _userManager.UpdateSecurityStampAsync(user);
                await _signInManager.SignOutAsync();
                await _signInManager.SignInAsync(user, true);
                CookieDelete("MANNAME");
                CookieCreate("MANNAME", model.Name);
                return View();
            }
            return View(model);
        }
        public async Task<IActionResult> AccountAdList()
        {
            var user =  await _userManager.FindByIdAsync(CookieDegeri("MANREF"));
            ViewBag.activeCount = (await _contentManager.GetAdListByUserWithStatu(user.Id,true)).Count;
            ViewBag.passiveCount = (await _contentManager.GetAdListByUserWithStatu(user.Id,false)).Count;
            var userContentMap = _contentFirmdocManager.GetAdListWithIMGByUser(int.Parse(CookieDegeri("MANREF"))).ToList();
            var mapList = userContentMap.Select(item =>
            {
                var contentViewModel = _mapper.Map<ContentViewModel>(item.Content);
                contentViewModel.firmDocs = new List<FirmDoc>();
                contentViewModel.firmDocs.Add(new FirmDoc { URL = item.URL });
                return contentViewModel;
            }).ToList();
            return View(mapList);
        }
        public async Task<IActionResult> GetActiveAdByUser()
        {
            int userId = int.Parse(CookieDegeri("MANREF"));
            var activeList = await _contentManager.GetAdListByUserWithStatu(userId, true);
            return Json(activeList);
        }
        public async Task<IActionResult> GetPassiveAdByUser()
        {
            int userId = int.Parse(CookieDegeri("MANREF"));
            var passiveList =  await _contentManager.GetAdListByUserWithStatu(userId, false);
            return Json(passiveList);
        }
        //public async Task<IActionResult> RemoveAd(int contentID)
        //{
        //    var content = _contentManager.TGetByID(contentID);
        //    _contentManager.TDelete(content);
        //    return RedirectToAction("AccountAdList", "Overview", new { area = "AccountSummary" });
        //}

        public async Task<IActionResult> RemoveAd(int ID)
        {
            var content = _contentManager.TGetByID(ID);
            _contentManager.TDelete(content);
            return RedirectToAction("AccountAdList", "Overview", new { area = "AccountSummary" });
        }
        public async Task<IActionResult> PublishAd(int ID)
        {
            var content = _contentManager.TGetByID(ID);
            _contentManager.SetActive(content);
            return RedirectToAction("AccountAdList", "Overview", new { area = "AccountSummary" });
        }
        public async Task<IActionResult> UpdateAd(Content content)
        {
            return View();
        }
        public async Task<IActionResult> AccountFavoritesList()
        {
            var userContentMap = _contentFirmdocManager.GetFavoriteListWithIMGByUser(int.Parse(CookieDegeri("MANREF")));
            int[] contentsID = userContentMap.Select(x => x.Content.ID).ToArray();
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
        public async Task<IActionResult> RemoveFavorite(int ID)
        {
            var content = _contentManager.TGetByID(ID);
            try
            {
                if (content != null)
                {
                    var deletedFavorite = _favoriteMapManager.TGetList().First(x => x.ContentID == content.ID);
                    _favoriteMapManager.TDelete(deletedFavorite);
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("string", "guncelleme sırasinda bir hata meydana geldi, URUN BULANAMADI!!");
            }
            return RedirectToAction("AccountFavoritesList", "Overview", new { area = "AccountSummary" });
        }
        public async Task<IActionResult> AddFavoriteList(int ID)
        {
            var UserID = int.Parse(CookieDegeri("MANREF"));
            if (ID != null && UserID != null)
            {
                ContentFavoriteMap model = new ContentFavoriteMap
                {
                    ContentID = ID,
                    UserID = int.Parse(CookieDegeri("MANREF")),

                };
                _favoriteMapManager.TAdd(model);
            }
            else
            {
                return BadRequest();
            }
            return RedirectToAction("AccountFavoritesList", "Overview", new { area = "AccountSummary" });
        }
    }
}

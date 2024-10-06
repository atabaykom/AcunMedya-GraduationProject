using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.ViewModels;
using System.Security.Claims;
using static BusinessLayer.Concrete.ContentFirmdocManager;

namespace RealEstate.Controllers
{
    [Authorize]
    public class AdvertisementController : BaseController
    {
        public AdvertisementController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IEmailSender emailSender, AccountManager accountManager, IMapper mapper, RoleManager<AppRole> roleManager, IUrlHelper urlHelper, IHttpContextAccessor httpContextAccessor, ContentManager contentManager, ContentCategoryManager contentCategoryManager, InComingMessageManager incomingMessageManager, OutGoingMessageManager outgoingMessagesManager, ContentFirmdocManager contentFirmdocManager, AccountManager user, MessageLineManager messageLineManager, ContentFavoriteMapManager contentFavoriteMapManager) : base(signInManager, userManager, emailSender, accountManager, mapper, roleManager, urlHelper, httpContextAccessor, contentManager, contentCategoryManager, incomingMessageManager, outgoingMessagesManager, contentFirmdocManager, user, messageLineManager, contentFavoriteMapManager)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult FilterResults(FilterViewModel filter)
        //{
        //    var map = _mapper.Map<Content>(filter);
        //    if (filter.maxm2 == null || filter.maxDues == null || filter.priceMax == null)
        //    {
        //        filter.priceMax = 10000000;
        //        filter.maxDues = 10000000;
        //        filter.maxm2 = 10000000;
        //    }
        //    var filteredList = _contentManager.GetContentByFilter(map, filter.priceMin, filter.priceMax, filter.minm2, filter.maxm2, filter.maxDues, filter.minDues);
        //    TempData["FilteredList"] = filteredList;
        //    return RedirectToAction("AdList");
        //}
        //[HttpPost]
        //public IActionResult FilterResults(FilterViewModel filter)
        //{
        //    var map = _mapper.Map<Content>(filter);
        //    if (filter.maxm2 == null || filter.maxDues == null || filter.priceMax == null)
        //    {
        //        filter.priceMax = 10000000;
        //        filter.maxDues = 10000000;
        //        filter.maxm2 = 10000000;
        //    }
        //    var filteredList = _contentManager.GetContentByFilter(map, filter.priceMin, filter.priceMax, filter.minm2, filter.maxm2, filter.maxDues, filter.minDues);
        //    var adList = _contentFirmdocManager.GetAdListWithIMGByStatu(true)
        //   .Where(x => filteredList.Select(y => y.ID).Contains(x.Content.ID))
        //     .Select(item => new ContentFirmDocViewModel { Content = item.Content, URL = item.URL })
        //      .ToList();
        //    return View("AdList", adList);
        //}
 

        [HttpGet]
        public async Task<IActionResult> AddNewAd()
        {
            GetCategories();
            return View();
        }

        public IActionResult GetCategories()
        {
            ContentCategoryManager categoryManager = new ContentCategoryManager(new EfContentCategoryDal());
            var categories = categoryManager.GetCategoryByStatu(true);
            var categoryList = categories.Select(c => new ContentCategoryViewModel 
            {   CategoryID = c.CATEGORYID, 
                CategoryName = c.CATNAME 
            }).ToList();
            return Json(categoryList);
        }
 
        [HttpPost]
        public async Task<IActionResult> AddNewAd(ContentViewModel model, IFormFileCollection images)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                model.ContentOwnerID = Convert.ToInt32(userId);
                var newAd = _mapper.Map<Content>(model);
                _contentManager.TAdd(newAd);
                foreach (var file in images)
                {
                    if (file.Length > 0)
                    {
                        byte[] imageData;
                        using (var memoryStream = new MemoryStream())
                        {
                            await file.CopyToAsync(memoryStream);
                            imageData = memoryStream.ToArray();
                        }

                        //string extension = Path.GetExtension(file.FileName);
                        string fileName = Guid.NewGuid().ToString(); //+ extension;
                        string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", fileName);
                        using (var stream = new FileStream(uploadPath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        string url = "/img/" + fileName+ "/.jpg";
                        FirmDoc f = new FirmDoc
                        {
                            IMGData = imageData,
                            ContentID = newAd.ID,
                            UserID = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value),
                            URL = url
                        };
                        try
                        {
                            FirmDocManager firmDoc = new FirmDocManager(new EfFirmDocDal());
                            firmDoc.TAdd(f);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("kayıt ekleme hatası: " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "İlan oluşturma sırasında bir hata oluştu!");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}

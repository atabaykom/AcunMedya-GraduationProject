using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Areas.AccountSummary.Models;
using RealEstate.Areas.Admin.Models;
using RealEstate.Areas.Admin.ViewModels;
using RealEstate.Controllers;
using RealEstate.ViewModels;
using System.Drawing.Printing;
using MessageViewModel = RealEstate.Areas.Admin.Models.MessageViewModel;
namespace RealEstate.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class HomeController : BaseController
    {
        public HomeController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IEmailSender emailSender, AccountManager accountManager, IMapper mapper, RoleManager<AppRole> roleManager, IUrlHelper urlHelper, IHttpContextAccessor httpContextAccessor, ContentManager contentManager, ContentCategoryManager contentCategoryManager, InComingMessageManager incomingMessageManager, OutGoingMessageManager outgoingMessagesManager, ContentFirmdocManager contentFirmdocManager, AccountManager user, MessageLineManager messageLineManager, ContentFavoriteMapManager contentFavoriteMapManager) : base(signInManager, userManager, emailSender, accountManager, mapper, roleManager, urlHelper, httpContextAccessor, contentManager, contentCategoryManager, incomingMessageManager, outgoingMessagesManager, contentFirmdocManager, user, messageLineManager, contentFavoriteMapManager)
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetAllContent()
        {
            ViewBag.activeCount = (_contentManager.GetAdListByStatu(true).Count);
            ViewBag.passiveCount = (_contentManager.GetAdListByStatu(false).Count);
            var userContentMap = _contentFirmdocManager.GetAdListWithIMG();
            var mapList = userContentMap.Select(item =>
            {
                var contentViewModel = _mapper.Map<ContentViewModel>(item.Content);
                contentViewModel.firmDocs = new List<FirmDoc>();
                contentViewModel.firmDocs.Add(new FirmDoc { URL = item.URL });
                return contentViewModel;
            }).ToList();
            return View(mapList);
        }
        public async Task<IActionResult> GetAllUser()
        {
            var userList =  _accountManager.TGetList();
            var roleList = _roleManager.Roles.ToList();
            ViewBag.roles = roleList;
            AdminUserViewModel ViewModel = new AdminUserViewModel   
            {
                Users = userList,
                Roles = roleList
            };
            return View(ViewModel);
        }
        public ActionResult GetRoles()
        {
            var roleList = _roleManager.Roles.ToList();
            return Json(new {roleList}); 
        }
        public async Task<IActionResult> GetAllCategories()
        {
            var categoryList = _contentCategoryManager.TGetList();
            return View(categoryList);
        }
        public async Task<IActionResult> GetAllMessageLines()
        {
            var lines = _messageLineManager.TGetList();
            var senderName = await _accountManager.GetName(lines.Select(x => x.SenderUserID).FirstOrDefault());
            var receiverName = await _accountManager.GetName(lines.Select(x => x.ReceiverUserID).FirstOrDefault());
            ViewBag.v1 = senderName;
            ViewBag.v2 = receiverName;
            ViewBag.TotalLines = lines.Count;
            ViewBag.itemsPerPage = 5; 
            return View(lines);
        }
        public async Task<IActionResult> GetAllInComingMessage()
        {
            var inComingMessageList = _incomingMessageManager.TGetList();
            var receiverName = await _accountManager.GetName(inComingMessageList.Select(x=>x.UserID).FirstOrDefault());
            ViewBag.v1 = receiverName;
            return View(inComingMessageList);
        }


        public async Task<IActionResult> GetAllOutGoingMessage()
        {
            var outGoingMessageList = _outgoingMessageManager.TGetList();
            return View(outGoingMessageList);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRole()
        {
            var RoleList = _roleManager.Roles.ToList();
            return View(RoleList);
        }
        [HttpGet]
        public async Task<IActionResult> AddNewRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewRole(AppRole model)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(model);

                if (result.Succeeded)
                {
                    return RedirectToAction("GetAllRole", "Home", new { area = "Admin" });
                }
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }
            return View(model);
        }
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role!=null)
            {
                await _roleManager.DeleteAsync(role);
                return RedirectToAction("GetAllRole", "Home", new { area = "Admin" });
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddUserRole(string userID, string roleID)
        {
            var user = await _userManager.FindByIdAsync(userID);
            var role = await _roleManager.FindByIdAsync(roleID);
            if (user != null&& role != null)
            {
               var asd= await _userManager.AddToRoleAsync(user, role.Name);
                if (!asd.Succeeded)
                {
                    foreach (var item in asd.Errors)
                    {
                        var asddd = item.Description;
                    }
                }
               return RedirectToAction("GetAllRole", "Home", new { area = "Admin" });
            }
            return View();
        }
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (id != null)
            {
                await _accountManager.DeleteUser(id);
                return RedirectToAction("GetAllUser", "Home", new { area = "Admin" });
            }
            return View();
        }
        public async Task<IActionResult> SetActiveUser(string id)
        {
            if (id != null)
            {
                await _accountManager.SetActiveUser(id);
                return RedirectToAction("GetAllUser", "Home", new { area = "Admin" });
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteInComingMessage(int id)
        {
            var message = _incomingMessageManager.TGetByID(id);
            if (message != null)
            {
                message.Status = 1001;
                _incomingMessageManager.TUpdate(message);
                return RedirectToAction("GetAllInComingMessage", "Home", new { area = "Admin" });
            }
            return View();
        }
        public async Task<IActionResult> DeletOutGoingMessage(int id)
        {
            var message = _outgoingMessageManager.TGetByID(id);
            if (message != null)
            {
                message.Status = 1001;
                _outgoingMessageManager.TUpdate(message);
                return RedirectToAction("GetAllOutGoingMessage", "Home", new { area = "Admin" });
            }
            return View();
        }
        public async Task<IActionResult> SetPassiveCategory (int id)
        {
            if (id!=null)
            {
               await _contentCategoryManager.SetPassiveCategory(id);
                return RedirectToAction("GetAllCategories", "Home", new { area = "Admin" });

            }
            return View();
        }
        public async Task<IActionResult> SetActiveCategory(int id)
        {
            if (id!=null)
            {
                await _contentCategoryManager.SetActiveCategory(id);
                return RedirectToAction("GetAllCategories", "Home", new { area = "Admin" });
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategoryName(ContentCategory model)
        {
            var category =  _contentCategoryManager.TGetByID(model.CATEGORYID);
            if (category!=null)
            {
                category.CATNAME = model.CATNAME;
                 _contentCategoryManager.TUpdate(category);
                return RedirectToAction("GetAllCategories", "Home", new { area = "Admin" });
            }
            return View("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCategoryName(int id)
        {
            var category = _contentCategoryManager.TGetByID(id);
            if (category != null)
            {
                return View(category);
            }
            return View("Index");
        }
        [HttpGet]
        public async Task<IActionResult> AddCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(ContentCategory model)
        {
            if (ModelState.IsValid)
            {
                _contentCategoryManager.TAdd(model);
                return RedirectToAction("GetAllCategories", "Home", new { area = "Admin" });
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role!=null)
            {
                return View(role);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRole(AppRole model)
        {
            var role = await _roleManager.FindByNameAsync(model.Name);
            if (ModelState.IsValid)
            {
                role.Name = model.Name;
                await _roleManager.UpdateAsync(model);
                return RedirectToAction("GetAllRole", "Home", new { area = "Admin" });
            }
            return View();
        }

        public async Task<IActionResult> RemoveAd(int id)
        {
            var content = _contentManager.TGetByID(id);
            _contentManager.TDelete(content);
            return RedirectToAction("Home", "GetAllContent", new { area = "Admin" });
        }
        public async Task<IActionResult> PublishAd(int id)
        {
            var content = _contentManager.TGetByID(id);
            _contentManager.SetActive(content);
            return RedirectToAction("Home", "GetAllContent", new { area = "Admin" });
        }
    }
}

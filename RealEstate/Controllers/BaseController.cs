using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Models;
using RealEstate.ViewModels;
using System.Net;

namespace RealEstate.Controllers
{
    public class BaseController : Controller
    {
        protected readonly SignInManager<AppUser> _signInManager;
        protected readonly UserManager<AppUser> _userManager;
        protected readonly IEmailSender _emailSender;
        protected readonly IMapper _mapper;
        protected readonly RoleManager<AppRole> _roleManager;
        protected readonly IUrlHelper _urlHelper;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly ContentManager _contentManager;
        protected readonly ContentCategoryManager _contentCategoryManager;
        protected readonly InComingMessageManager _incomingMessageManager;
        protected readonly OutGoingMessageManager _outgoingMessageManager;
        protected readonly ContentFirmdocManager _contentFirmdocManager;
        protected readonly MessageLineManager _messageLineManager;
        protected readonly ContentFavoriteMapManager _favoriteMapManager;
        protected readonly MessageRefManager _messageRefManager;
        protected readonly AccountManager _accountManager;


        public BaseController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IEmailSender emailSender, AccountManager accountManager, IMapper mapper, RoleManager<AppRole> roleManager, IUrlHelper urlHelper, IHttpContextAccessor httpContextAccessor, ContentManager contentManager, ContentCategoryManager contentCategoryManager, InComingMessageManager incomingMessageManager, OutGoingMessageManager outgoingMessagesManager, ContentFirmdocManager contentFirmdocManager, AccountManager user, MessageLineManager messageLineManager, ContentFavoriteMapManager contentFavoriteMapManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _emailSender = emailSender;
            _mapper = mapper;
            _roleManager = roleManager;
            _urlHelper = urlHelper;
            _httpContextAccessor = httpContextAccessor;
            _contentManager = new ContentManager(new EfContentDal(), userManager);
            _contentCategoryManager = new ContentCategoryManager(new EfContentCategoryDal());
            _incomingMessageManager = new InComingMessageManager(new EfIncomingMessageDal());
            _outgoingMessageManager = new OutGoingMessageManager(new EfOutgoingMessageDal());
            _contentFirmdocManager = contentFirmdocManager;
            _accountManager = accountManager;
            _messageLineManager = new MessageLineManager(new EfMessageLineDal());
            _favoriteMapManager = new ContentFavoriteMapManager(new EfContentFavoriteMapDal());
            _messageRefManager = new MessageRefManager(new EFMessageRefDal());
        }

        public IActionResult Index()
        {
            return View();
        }
        public AccountManager CreateAppUserManager()
        {
            return new AccountManager(_userManager, new EfAccountDal(), _emailSender);
        }


        public string CookieDegeri(string CookieAdi)
        {
            if (Request.Cookies[CookieAdi] != null)
            {
                try
                {
                    string cookieValue = Request.Cookies[CookieAdi].ToString(); 
                    return Uri.UnescapeDataString(cookieValue).Trim(); 
                }
                catch { }
            }
            return "";
        }
        public void CookieDelete(string cookievalue) {
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTimeOffset.UtcNow.AddYears(-1);
            Response.Cookies.Delete(cookievalue, cookieOptions);
        }

        public void CookieCreate(string cookieKey, string cookieValue)
        {
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.IsEssential = true;
            cookieOptions.Expires = DateTimeOffset.UtcNow.AddHours(2);
            Response.Cookies.Append(cookieKey, cookieValue.ToString(),cookieOptions);
           // Response.Cookies.Append("MANREF", user.Id.ToString(), cookie);
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            var cookieOptions = new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddYears(-1) // Çerezin süresini geçmiş bir tarihe ayarlar, böylece tarayıcı tarafından silinir
            };

            //Response.Cookies.Delete("MANREF", cookieOptions);
            //Response.Cookies.Delete("MANNAME", cookieOptions);
            // Response.Cookies.Append("MANEMAIL", user.Email, cookie);
            CookieDelete("MANREF");
            CookieDelete("MANNAME");
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> LogIn(UserLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    await _signInManager.SignOutAsync();

                    if (!await _userManager.IsEmailConfirmedAsync(user))
                    {
                        ModelState.AddModelError("", "Hesabınızı onaylayınız.");
                        return View(model);
                    }

                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, true);

                    if (result.Succeeded)
                    {
                        await _userManager.ResetAccessFailedCountAsync(user);
                        await _userManager.SetLockoutEndDateAsync(user, null);
                        //var claims = new List<Claim> //calismiyor
                        //{
                        //   new Claim(ClaimTypes.Name, user.Name),
                        //   new Claim(ClaimTypes.Email, user.Email)
                        //};
                        //var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        //var authProperties = new AuthenticationProperties
                        //{
                        //    IsPersistent = true,
                        //    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60)
                        //};
                        //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);


                        //Response.Cookies.Append("useridfromcookie", user.Id.ToString(), new CookieOptions // calisiyor.
                        //{
                        //    IsEssential = true, 
                        //    Expires = DateTimeOffset.UtcNow.AddMinutes(60)
                        //});
                        //var cookie = new CookieOptions
                        //{
                        //    IsEssential = true,
                        //    Expires = DateTimeOffset.UtcNow.AddHours(2)
                        //};
                        //Response.Cookies.Append("MANREF", user.Id.ToString(), cookie);
                        //Response.Cookies.Append("MANNAME", user.Name.ToString(), cookie);
                        CookieCreate("MANREF", user.Id.ToString());
                        CookieCreate("MANNAME", user.Name);
                        // Response.Cookies.Append("MANEMAIL", user.Email,cookie);

                        return RedirectToAction("Index", "Home");
                    }
                    else if (result.IsLockedOut)
                    {
                        var lockoutDate = await _userManager.GetLockoutEndDateAsync(user);
                        var timeLeft = lockoutDate.Value - DateTime.UtcNow;
                        ModelState.AddModelError("", $"Hesabınız kitlendi, Lütfen {timeLeft.Minutes} dakika sonra deneyiniz");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Email ya da Sifre Hatalı!");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Email ya da Sifre Hatalı!");
                }
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserCreateViewModel model)
        {
            var errorText = "";
            if (!ModelState.IsValid)
            {
                return BadRequest("Eksik veri girişi yaptınız!");
            }
            var content = new FormUrlEncodedContent(new Dictionary<string, string> {
            { "secret","6Lf75YgpAAAAALLiizZuUDzZIIBO3IV2vi2W7F1D" },
            { "response", model.ReCaptchaResponse}});
            var client = new HttpClient();
            var response = await client.PostAsync("https://www.google.com/recaptcha/api/siteverify", content);
            if (response.IsSuccessStatusCode)
            {
                var result2 = await response.Content.ReadFromJsonAsync<reCaptchaResponse>();
            }
            else
            {
                errorText = "Doğrulama başarısız!";
                return StatusCode(500, errorText);
            }
            try
            {
                var user = new AppUser
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    UserName = model.UserName,
                    Email = model.Email,
                    IsActive = true
                };
                await _accountManager.CreateUser(user, model.Password);
                return RedirectToAction("Base", "Login");
            }
            catch (Exception)
            {
                return StatusCode(500, "Kullanıcı oluşturma sırasında bir hata oluştu");
            }
        }

        public async Task<IActionResult> ConfirmEmail(string Id, string token)
        {
            try
            {
                await _accountManager.ConfirmEmail(Id, token);
                return RedirectToAction("Index", "Login");
            }
            catch (Exception)
            {
                return StatusCode(500, "E-posta doğrulama sırasında bir hata oluştu");
            }
        }
    }
}

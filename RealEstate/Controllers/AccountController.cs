using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Models;
using RealEstate.ViewModels;

namespace RealEstate.Controllers
{
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IEmailSender emailSender, AccountManager accountManager, IMapper mapper, RoleManager<AppRole> roleManager, IUrlHelper urlHelper, IHttpContextAccessor httpContextAccessor, ContentManager contentManager, ContentCategoryManager contentCategoryManager, InComingMessageManager incomingMessageManager, OutGoingMessageManager outgoingMessagesManager, ContentFirmdocManager contentFirmdocManager, AccountManager user, MessageLineManager messageLineManager, ContentFavoriteMapManager contentFavoriteMapManager) : base(signInManager, userManager, emailSender, accountManager, mapper, roleManager, urlHelper, httpContextAccessor, contentManager, contentCategoryManager, incomingMessageManager, outgoingMessagesManager, contentFirmdocManager, user, messageLineManager, contentFavoriteMapManager)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Register()
        {
            return View();
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
                return RedirectToAction("Index", "Login");
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
        [HttpPost]
        public async Task<IActionResult> Login()
        {
            return View();
        }
       
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel model)
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
                        var roles = await _userManager.GetRolesAsync(user);
                        var roleName = roles.FirstOrDefault();


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
                        var cookie = new CookieOptions
                        {
                            IsEssential = true,
                            Expires = DateTimeOffset.UtcNow.AddHours(2)
                        };  
                        Response.Cookies.Append("MANREF", user.Id.ToString(), cookie);
                        Response.Cookies.Append("MANNAME", user.Name.ToString(), cookie);
                        Response.Cookies.Append("MANROLE", roleName?.ToString() ?? "default_role", cookie);

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
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            var cookieOptions = new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddYears(-1) 
            };

            Response.Cookies.Delete("MANREF", cookieOptions);
            Response.Cookies.Delete("MANNAME", cookieOptions);
            Response.Cookies.Delete("MANROLE");
            // Response.Cookies.Append("MANEMAIL", user.Email, cookie);
            return RedirectToAction("Index", "Home");
        }
    }
}

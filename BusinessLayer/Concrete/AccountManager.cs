using Azure;
using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using System.Net;

using System.Web;
namespace BusinessLayer.Concrete
{
    public class AccountManager : IAccountService
    {
        public readonly UserManager<AppUser> _userManager;
        IAccountDal _accountDal;
        private IEmailSender _emailSender;
        public AccountManager(UserManager<AppUser> userManager, IAccountDal accountDal, IEmailSender emailSender)
        {
            _userManager = userManager;
            _accountDal = accountDal;
            _emailSender = emailSender;
        }

        public void TAdd(AppUser t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(AppUser t)
        {
            _accountDal.Delete(t);
        }

        public AppUser TGetByID(int id)
        {
            return _accountDal.GetByID(id);
        }

        public List<AppUser> TGetList()
        {
            return _accountDal.GetList();
        }

        public List<AppUser> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(AppUser t)
        {
            _accountDal.Update(t);
        }
        public async Task CreateUser(AppUser user, string password)
        {
            IdentityResult result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var encodedToken = WebUtility.UrlEncode(token);
                // await _emailSender.SendEmailAsync(user.Email, "Hesap Onayı", url);
            }
            else
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"Kullanıcı oluşturma hatası: {errors}");
            }
        }


        public async Task ConfirmEmail(string Id, string token)
        {
            var user = await _userManager.FindByIdAsync(Id);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (!result.Succeeded)
                {
                    throw new Exception("E-posta doğrulama hatası");
                }
            }
        }

        public async Task DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                user.IsActive = false;
                await _userManager.UpdateAsync(user);
            }
        }
        public async Task SetActiveUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                user.IsActive = true;
                await _userManager.UpdateAsync(user);
            }
        }

        public async Task<string> GetName(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            return user.Name;
        }
    }
}


using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace BusinessLayer.Abstract
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}

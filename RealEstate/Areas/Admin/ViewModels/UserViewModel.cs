using EntityLayer.Concrete;

namespace RealEstate.Areas.Admin.ViewModels
{
    public class AdminUserViewModel
    {
        public List<AppUser> Users { get; set; }
        public List<AppRole> Roles { get; set; }
    }
}

using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace BusinessLayer.Concrete
{
    public class ContentManager : IContentService
    {
        public readonly UserManager<AppUser> _userManager;
        IContentDal _contentDal;
        public ContentManager(IContentDal contentDal, UserManager<AppUser>? userManager=null)
        {
            _userManager = userManager;
            _contentDal = contentDal;
        }
        public List<Content> GetFeaturedAdList(int count)
		{
            return _contentDal.GetByFilter(r => r.IsActive).OrderByDescending(r => r.CreatedDate).Take(count).ToList(); 
		}

		public List<Content> GetAdListByStatu(bool p)
		{
			return _contentDal.GetByFilter(r => r.IsActive == p).OrderByDescending(r => r.CreatedDate).ToList();
		}

		public async void TAdd(Content t)
        {
            var userId = t.ContentOwnerID;
            var result = await CheckUserAsync(userId);
            if (result == 1)
            {
                t.CreatedDate = DateTime.Now.AddSeconds(1);
                t.IsActive = true;
                _contentDal.Insert(t);
            }
        }
        public async Task<int> CheckUserAsync(int userID)
        {
            var user = _userManager.Users.FirstOrDefaultAsync(u => u.Id == userID).GetAwaiter().GetResult();

            if (user.EmailConfirmed!=true)
            {
                throw new Exception("E-posta doğrulama hatası");
            }
            if (user.IsActive!=true)
            {
                throw new Exception("Kullanıcı doğrulama hatası");
            }
            if (user.LockoutEnabled!=true)
            {
                throw new Exception("Kullanıcı doğrulama hatası");
            }
            return 1;
        }
        public void TDelete(Content t)
        {
            t.IsActive = false;
            _contentDal.Update(t);
        }

        public void SetActive(Content t)
        {
            t.IsActive = true;
            _contentDal.Update(t);
        }
        public Content TGetByID(int id)
        {
            return _contentDal.GetByID(id);
        }

        public List<Content> TGetList()
        {
            return _contentDal.GetList();
        }

        public List<Content> TGetListByFilter()
        {
            throw new NotImplementedException();
		}

        public async void TUpdate(Content t)
        {
              _contentDal.Update(t);
        }

        public List<Content> GetAdListByUser(int userId)
        {
            return _contentDal.GetList().Where(x => x.ContentOwnerID == userId).OrderBy(x=>x.CreatedDate).ToList();
        }

        public async Task<List<Content>> GetAdListByUserWithStatu(int userId, bool p)
        {
            return  _contentDal.GetByFilter(x => x.ContentOwnerID == userId && x.IsActive == p).ToList();
        }

        public async Task<List<Content>> GetAdCountByCategory(int categoryID)
        {
            return _contentDal.GetByFilter(x => x.CategoryID == categoryID && x.IsActive).ToList();
        }

        public List<Content> GetUserFavoriteList(int[] ads)
        {
            return _contentDal.GetList().Where(x => ads.Contains(x.ID)).ToList();
        }

        public List<Content> GetContentByFilter(Content content, int? minPrice, int? maxPrice, int? minm2, int? maxm2, int? maxDues, int? minDues)
        {
            var query = _contentDal.GetList().Where(x =>
                (content.Country == null || x.Country == content.Country) &&
                (content.CategoryID <= 0 && content.CategoryID!=null || x.CategoryID == content.CategoryID) &&
                (content.City == null || x.City == content.City) &&
                (content.Town == null || x.Town == content.Town) &&
                (content.AgeOfBuilding == null || x.AgeOfBuilding == content.AgeOfBuilding) &&
                (content.ContentFrom == null || x.ContentFrom == content.ContentFrom) &&
                (content.Balcony == null || x.Balcony == content.Balcony) &&
                (content.Elevator == null || x.Elevator == content.Elevator) &&
                (content.Exchangeable == null || x.Exchangeable == content.Exchangeable) &&
                (content.FloorNumber == null || x.FloorNumber == content.FloorNumber) &&
                (content.NumberOfFloors == null || x.NumberOfFloors == content.NumberOfFloors) &&
                (content.NumberOfRooms == null || x.NumberOfRooms == content.NumberOfRooms) &&
                (content.ContentType == null || x.ContentType == content.ContentType) &&
                (content.NumberOfBathrooms == null || x.NumberOfBathrooms == content.NumberOfBathrooms) &&
                (content.ParkingArea == null || x.ParkingArea == content.ParkingArea) &&
                ((minPrice == null && x.Price >= 1 && x.Price <= 10000000) || (x.Price >= minPrice)) &&
                ((maxPrice == null && x.Price >= 1 && x.Price <= 10000000) || (x.Price <= maxPrice)) &&
                ((minm2 == null && x.NetSquareMeters >= 1 && x.NetSquareMeters <= 10000000) || (x.NetSquareMeters >= minm2)) &&
                ((maxm2 == null && x.NetSquareMeters >= 1 && x.NetSquareMeters <= 10000000) || ( x.NetSquareMeters <= maxm2)) &&
                ((minDues == null && x.Dues >= 1 && x.Dues <= 10000000) || (x.Dues >= minDues)) &&
                ((maxDues == null && x.Dues >= 1 && x.Dues <= 10000000) || (x.Dues <= maxDues))
            ).ToList();
            return query;
        }
    }
}

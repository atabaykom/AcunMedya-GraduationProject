using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContentCategoryManager : IContentCategoryService
    {
        IContentCategoryDal _contentCategoryDal;

    
        public ContentCategoryManager(IContentCategoryDal contentCategoryDal)
        {
            _contentCategoryDal = contentCategoryDal;
        }
        public async Task SetPassiveCategory(int id)
        {
            var category = TGetByID(id);
            if (category != null)
            {
                category.ISACTIVE = false;
                TUpdate(category);
            }
        }
        public async Task SetActiveCategory(int id)
        {
            var category = TGetByID(id);
            if (category != null)
            {
                category.ISACTIVE = true;
                TUpdate(category);
            }
        }
        public List<ContentCategory> GetCategoryByStatu(bool p)
		{
            return _contentCategoryDal.GetByFilter(r=>r.ISACTIVE==p).ToList();
		}

		public void TAdd(ContentCategory t)
        {
            _contentCategoryDal.Insert(t);
        }

        public void TDelete(ContentCategory t)
        {
            _contentCategoryDal.Delete(t);
        }

        public ContentCategory TGetByID(int id)
        {
            return _contentCategoryDal.GetByID(id);
        }

        public List<ContentCategory> TGetList()
        {
            return _contentCategoryDal.GetList();
        }

		public List<ContentCategory> TGetListByFilter()
		{
			throw new NotImplementedException();
		}

		public void TUpdate(ContentCategory t)
        {
            _contentCategoryDal.Update(t);
        }

        public async Task<ContentCategory> GetCategoryID(string name)
        {
            var category = _contentCategoryDal.GetByFilter(x => x.CATNAME == name).FirstOrDefault();
            return category;
        }
    }
}

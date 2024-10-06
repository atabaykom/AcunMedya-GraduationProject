using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentCategoryService:IGenericService<ContentCategory>
    {
		List<ContentCategory> GetCategoryByStatu(bool p);
        Task<ContentCategory> GetCategoryID(string name);
	}
}

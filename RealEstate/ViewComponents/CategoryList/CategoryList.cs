using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace RealEstate.ViewComponents.Categories
{
	public class CategoryList:ViewComponent
	{
		ContentCategoryManager categoryManager = new ContentCategoryManager(new EfContentCategoryDal());
		ContentManager contentManager = new ContentManager(new EfContentDal());
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var categoryList =  categoryManager.GetCategoryByStatu(true);
			return View(categoryList);
		}
	}
}

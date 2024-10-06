using AutoMapper;
using BusinessLayer;
using BusinessLayer.Concrete;
using DataAccesLayer.Abstract;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using RealEstate.ViewModels;

namespace RealEstate.ViewComponents.HomepageFeaturedAds
{
    public class RecentAdsList : ViewComponent
	{
		IMapper _mapper;
		ContentFirmdocManager _contentFirmdocManager;
		ContentManager _contentManager;
		FirmDocManager _firmdocManager;
		public RecentAdsList(IMapper mapper)
		{
			_mapper = mapper;
			_firmdocManager = new FirmDocManager(new EfFirmDocDal());
            _contentManager = new ContentManager(new EfContentDal());
            _contentFirmdocManager = new ContentFirmdocManager(new EfContentDal(),new EfFirmDocDal());
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var FeaturedAds = _contentManager.GetFeaturedAdList(4);
			var mapList = new List<ContentViewModel>();
			foreach (var item in FeaturedAds)
			{
				var a = _mapper.Map<ContentViewModel>(item);
				var IMGList = _firmdocManager.TGetList().Where(x=>x.ContentID == item.ID).ToList();
				a.firmDocs = IMGList;
				mapList.Add(a);
			}
			return View(mapList);


		//	var IMGList = firmdoc.GetAdIMG(id).ToList();
		//	var map = _mapper.Map<ContentViewModel>(content);
		//	if (IMGList.Count > 1)
		//	{
		//		map.firmDocs = IMGList;
		//	}
		//	else if (IMGList.Count == 0)
		//	{
		//		map.firmDocs = new List<FirmDoc>();
		//		map.firmDocs.Add(new FirmDoc { URL = "/img/NoIMG.jpg" });
		//	}
		//	var mapList = new List<ContentViewModel> { map };
		}
	}
}

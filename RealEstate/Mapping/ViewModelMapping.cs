using AutoMapper;
using EntityLayer.Concrete;
using RealEstate.Areas.AccountSummary.Models;
using RealEstate.Areas.Admin.Models;
using RealEstate.ViewModels;
using MessageViewModel = RealEstate.Areas.Admin.Models.MessageViewModel;

namespace RealEstate.Mapping
{
	public class ViewModelMapping:Profile
	{
		public ViewModelMapping() {
			CreateMap<Content, ContentViewModel>().ReverseMap();
			CreateMap<ContentCategory, ContentCategoryViewModel>().ReverseMap();
			CreateMap<FirmDoc, FirmDocViewModel>().ReverseMap();
			CreateMap<AppUser, UserViewModel>().ReverseMap();
			CreateMap<Content, FilterViewModel>().ReverseMap();
			CreateMap<MessageLine, MessageViewModel>().ReverseMap();
			CreateMap<OutgoingMessage, MessageViewModel>().ReverseMap();
			CreateMap<IncomingMessage, MessageViewModel>().ReverseMap();
		}
	}
}

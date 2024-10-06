using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccesLayer.Abstract;
using DataAccesLayer.EntityFramework;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using RealEstate.Areas.AccountSummary.Models;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using static BusinessLayer.Concrete.ContentFirmdocManager;

namespace RealEstate.Areas.AccountSummary.ViewComponents
{
    public class MessageInbox : ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly InComingMessageManager _incomingmessageManager;
        private readonly OutGoingMessageManager _outGoingMessageManager;
        private readonly MessageLineManager _messageLineManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly MessageRefManager _messageRefManager;

        public MessageInbox(IMapper mapper,UserManager<AppUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _incomingmessageManager = new InComingMessageManager(new EfIncomingMessageDal());
            _outGoingMessageManager = new OutGoingMessageManager(new EfOutgoingMessageDal());
            _messageLineManager = new MessageLineManager(new EfMessageLineDal());
            _messageRefManager = new MessageRefManager(new EFMessageRefDal());
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userFromCookie = Convert.ToInt32(HttpContext.Request.Cookies["MANREF"]);
            var box = _messageLineManager.GetMessageBoxByUserID(userFromCookie);
            var list = new List<MessageViewModel>();
            foreach (var item in box)
            {
                var sender = await _userManager.FindByIdAsync(item.SenderUserID.ToString());
                var receiver = await _userManager.FindByIdAsync(item.ReceiverUserID.ToString());
                MessageViewModel model = new MessageViewModel()
                {
                    Content = item.Content,
                    SenderUserID = item.SenderUserID,
                    SenderName = sender.Name,
                    ReceiverName = receiver.Name,
                    ReceiverUserID = item.ReceiverUserID,
                    ID = item.MREF,
                };
                list.Add(model);
            }
            return View(list);
            //var box = _incomingmessageManager.GetIncomingMessagesBox(userFromCookie);
            //var head = _messageLineManager.GetMessagesDetailByUserID(userFromCookie);
            //var list = new List<MessageViewModel>();
            //foreach (var item in box)
            //{
            //    var conversationInfo = _messageLineManager.GetMessages(box.Select(x => x.CID).Skip(box.IndexOf(item)).FirstOrDefault());
            //    if (conversationInfo != null)
            //    {
            //        var senderUserID = conversationInfo.FirstOrDefault(x => x.SenderUserID != userFromCookie);
            //        MessageViewModel model = new MessageViewModel()
            //        {
            //            Content = conversationInfo.Last().Content,
            //            Date = box.Last().Date,
            //            ReceiverUserID = userFromCookie,
            //            SenderName = box.First().SenderName,
            //            SenderUserID = conversationInfo.Select(x => x.SenderUserID).FirstOrDefault(),
            //            ID = item.CID,
            //        };
            //    }
            //}
            //return View(list);


            //select MF.MID, L.Content,L.ReceiverUserID,(select name from AspNetUsers where Id = ReceiverUserID ) as ReceiverName,
            //L.SenderUserID,
            //(select name from AspNetUsers where Id = L.SenderUserID)AS SenderName
            //FROM MessageRef MF
            //INNER JOIN
            //MessageLine AS L
            //ON MF.CREF = L.MREF
        }
    }
}

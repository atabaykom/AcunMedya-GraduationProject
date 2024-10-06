using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using RealEstate.Areas.AccountSummary.Models;
using RealEstate.Controllers;

namespace RealEstate.Areas.AccountSummary.Controllers
{
    [Area("AccountSummary")]
    [Authorize]
    public class AccountMessageController : BaseController
    {
        public AccountMessageController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IEmailSender emailSender, AccountManager accountManager, IMapper mapper, RoleManager<AppRole> roleManager, IUrlHelper urlHelper, IHttpContextAccessor httpContextAccessor, ContentManager contentManager, ContentCategoryManager contentCategoryManager, InComingMessageManager incomingMessageManager, OutGoingMessageManager outgoingMessagesManager, ContentFirmdocManager contentFirmdocManager, AccountManager user, MessageLineManager messageLineManager, ContentFavoriteMapManager contentFavoriteMapManager) : base(signInManager, userManager, emailSender, accountManager, mapper, roleManager, urlHelper, httpContextAccessor, contentManager, contentCategoryManager, incomingMessageManager, outgoingMessagesManager, contentFirmdocManager, user, messageLineManager, contentFavoriteMapManager)
        {
        }

        public string CookieDegeri(string CookieAdi)
        {
            if (Request.Cookies[CookieAdi] != null)
            {
                try
                {
                    string cookieValue = Request.Cookies[CookieAdi].ToString();
                    return Uri.UnescapeDataString(cookieValue).Trim();
                }
                catch { }
            }
            return "";
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]   
        public async Task<IActionResult> MessageBox()
        {
            var userFromCookie = Convert.ToInt32(HttpContext.Request.Cookies["MANREF"]);
            //var box = _messageLineManager.GetMessagesDetailByUserID(Convert.ToInt32(CookieDegeri("MANREF")));
            //var list = new List<MessageViewModel>();
            //foreach (var item in box)
            //{
            //    var conversationInfo = _messageLineManager.GetMessages(box.Select(x => x.MREF).Skip(box.IndexOf(item)).FirstOrDefault());
            //    if (conversationInfo != null) {

            //    var senderUserID = conversationInfo.FirstOrDefault(x => x.SenderUserID != Convert.ToInt32(CookieDegeri("MANREF").ToString()))?.SenderUserID;
            //    MessageViewModel model = new MessageViewModel()
            //    {
            //        Content = conversationInfo.Last().Content,
            //        Date = conversationInfo.Last().Date_,
            //        ReceiverName = CookieDegeri("MANNAME").ToString(),
            //        ReceiverUserID = Convert.ToInt32(CookieDegeri("MANREF").ToString()),
            //        SenderUserID = senderUserID ?? 0,
            //        ID = item.MREF,
            //    };
            //        list.Add(model);
            //    }
            //}
            //return View(list.GroupBy(x=>x.ID));
            var box = _messageLineManager.GetMessageBoxByUserID(userFromCookie);
            var list = new List<MessageViewModel>();
            foreach (var item in box)
            {
                var senderName = await _accountManager.GetName(item.SenderUserID);
                var receiverName = await _accountManager.GetName(item.ReceiverUserID);
                MessageViewModel model = new MessageViewModel() { 
                    Content = item.Content,
                    SenderUserID = item.SenderUserID,
                    SenderName = senderName,
                    ReceiverName = receiverName,
                    ReceiverUserID = item.ReceiverUserID,
                    ID = item.MREF,
                };
                list.Add(model);
                //var conversationInfo = _messageLineManager.GetMessages(box.Select(x => x.).Skip(box.IndexOf(item)).FirstOrDefault());
                //if (conversationInfo != null)
                //{
                //    var senderUserID = conversationInfo.FirstOrDefault(x => x.SenderUserID != userFromCookie);
                //    MessageViewModel model = new MessageViewModel()
                //    {
                //        Content = conversationInfo.Last().Content,
                //        Date = box.Last().Date_,
                //        ReceiverUserID = userFromCookie,
                //        SenderName = box.First().sender,
                //        SenderUserID = conversationInfo.Select(x => x.SenderUserID).FirstOrDefault(),
                //        ID = item.CID,
                //    };
                //}
            }
                return View(list);
        }
        [HttpPost]
        public async Task<IActionResult> SendNewMessage(MessageViewModel model)
        {
            if (model.Content != null)
            {
                try
                {
                    var UserID = Convert.ToInt32(CookieDegeri("MANREF"));
                    var SenderName = CookieDegeri("MANNAME").ToString();
                    var mreflist = _messageRefManager.TGetList();
                    model.SenderUserID = UserID;
                    model.SenderName = SenderName;
                    var header = _messageLineManager.GetMessagesDetailByTwoUserID(model.ReceiverUserID, UserID, model.ID);
                    if (!(header.Count > 0))
                    {
                        var messageRefs = _messageRefManager.TGetList();
                        var maxCref = messageRefs.Any() ? messageRefs.Max(m => m.CREF) : 0;
                        MessageRef newMessage = new MessageRef()
                        {
                            CREF = maxCref + 1
                        };
                        _messageRefManager.TAdd(newMessage);
                    }
                    OutgoingMessage Outgoingmessage = new OutgoingMessage()
                    {
                        UserID = UserID,
                        SenderName = SenderName,
                        Content = model.Content,
                        Date = DateTime.Now,
                        Status = 1020,
                    };
                    _outgoingMessageManager.TAdd(Outgoingmessage);

                    IncomingMessage IncomingMessage = new IncomingMessage()
                    {
                        UserID = model.ReceiverUserID,
                        SenderName = SenderName,
                        Content = model.Content,
                        Date = DateTime.Now,
                        Status = 1020,
                    };
                    _incomingMessageManager.TAdd(IncomingMessage);

                    MessageLine messageLine = new MessageLine()
                    {
                        SenderUserID = UserID,
                        Content = model.Content,
                        Status = 1,
                        Date_ = DateTime.Now,
                        ReceiverUserID = model.ReceiverUserID,
                        MREF = model.ID
                    };
                    _messageLineManager.TAdd(messageLine);
                    Outgoingmessage.CID = messageLine.MREF;
                    IncomingMessage.CID = messageLine.MREF;
                    _outgoingMessageManager.TUpdate(Outgoingmessage);
                    _incomingMessageManager.TUpdate(IncomingMessage);

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hata oluştu: " + ex.Message);
                }
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("AccountSummary/AccountMessage/MessageDetail/{messageID}/{sentUser}")]
        public async Task<IActionResult> MessageDetail(int messageID, int sentUser)
        {
            var checkID = _contentManager.TGetByID(messageID);
            var userFromCookie = Convert.ToInt32(CookieDegeri("MANREF"));
            if (checkID!=null &&userFromCookie > 0 && sentUser > 0 && userFromCookie!=sentUser)
            {
                var header = _messageLineManager.GetMessagesDetailByTwoUserID(userFromCookie,sentUser,messageID);
                //var userlist = _accountManagerManager.Users.ToList();
                //var mreflist = _messageRefManager.TGetList();
                //var xy = from mf in mreflist
                //         join l in header on mf.CREF equals l.MREF
                //         join sender in userlist on l.SenderUserID equals sender.Id
                //         join receiver in userlist on l.ReceiverUserID equals receiver.Id
                //         where mf.CREF == messageID
                //         orderby l.Date_
                //         select new MessageViewModel
                //         {
                //             ID = mf.MID,
                //             Content = l.Content,
                //             ReceiverUserID = receiver.Id,
                //             ReceiverName = receiver.Name,
                //             SenderUserID = l.SenderUserID,
                //             SenderName = sender.Name
                //         };
                var xy = new List<MessageViewModel>();
                foreach (var item in header)
                {
                    var senderName = await _accountManager.GetName(item.SenderUserID);
                    var receiverName = await _accountManager.GetName(item.ReceiverUserID);
                    var model =new MessageViewModel()
                    { 
                        ID = item.MREF,
                        Content = item.Content,
                        Date = item.Date_,
                        SenderUserID = item.SenderUserID,
                        SenderName = senderName,
                        ReceiverUserID = item.ReceiverUserID,
                        ReceiverName = receiverName,
                    };
                    xy.Add(model);
                }
                return View(xy);
            }
            return NotFound();
        }
    }
}
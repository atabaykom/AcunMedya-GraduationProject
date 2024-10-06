using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class InComingMessageManager : IIncomingMessageService
    {
       IIncomingMessageDal _incomingMessageDal;

        public InComingMessageManager(IIncomingMessageDal incomingMessageDal)
        {
            _incomingMessageDal = incomingMessageDal;
        }

        public List<IncomingMessage> GetIncomingMessages(int UserID)
        {
            return _incomingMessageDal.GetList().Where(x=>x.UserID == UserID).ToList();
        }

        public List<IncomingMessage> GetIncomingMessagesBox(int UserID)
        {
            var messageLines = _incomingMessageDal.GetList().Where(x => x.UserID == UserID).ToList();
            var groupedMessages = messageLines
                .OrderBy(x => x.Date)
                .GroupBy(x => x.CID)
                .Select(group => group.First())
                .ToList();
            return groupedMessages;
        }

        public void TAdd(IncomingMessage t)
        {
            _incomingMessageDal.Insert(t);
        }

        public void TDelete(IncomingMessage t)
        {
            throw new NotImplementedException();
        }

        public IncomingMessage TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<IncomingMessage> TGetList()
        {
            return _incomingMessageDal.GetList();
        }

        public List<IncomingMessage> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(IncomingMessage t)
        {
            _incomingMessageDal.Update(t);
        }
    }
}

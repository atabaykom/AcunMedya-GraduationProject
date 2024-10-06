using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageLineManager : IMessageLineService
    {
        IMessageLineDal _messageLineDal;
        public MessageLineManager(IMessageLineDal messageLineDal)
        {
            _messageLineDal = messageLineDal;
        }


        public List<MessageLine> GetMessageBoxByUserID(int userID)
        {
            return _messageLineDal.GetList()
                .Where(x => x.SenderUserID == userID || x.ReceiverUserID == userID)
                .GroupBy(x => x.MREF)
                .SelectMany(group => group.OrderByDescending(x => x.Date_).Take(1))
                .ToList();
        }


        public List<MessageLine> GetMessages(int MessageID)
        {
           return  _messageLineDal.GetList().Where(x => x.MREF==MessageID).ToList();
        }

        public List<MessageLine> GetMessagesDetailByTwoUserID(int userIDOne, int UserIDTwo,int MessageID)
        {
            var list = _messageLineDal.GetList()
                      .Where(x => (x.ReceiverUserID == userIDOne && x.SenderUserID == UserIDTwo) || (x.ReceiverUserID == UserIDTwo && x.SenderUserID == userIDOne))
                      .OrderBy(x => x.Date_);
            return list.Where(x=>x.MREF == MessageID).ToList();
        }

        public List<MessageLine> GetMessagesDetailByUserID(int userID)
        {
            return _messageLineDal.GetList().Where(x => x.SenderUserID == userID || x.ReceiverUserID == userID).ToList();
        }

        public void TAdd(MessageLine t)
        {
            _messageLineDal.Insert(t);
        }

        public void TDelete(MessageLine t)
        {
            throw new NotImplementedException();
        }

        public MessageLine TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<MessageLine> TGetList()
        {
            return _messageLineDal.GetList();

        }

        public List<MessageLine> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(MessageLine t)
        {
            throw new NotImplementedException();
        }
       
    }
}

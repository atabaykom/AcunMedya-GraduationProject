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
    public class OutgoingMessagesManager : IOutgoingMessageService
    {
        IOutgoingMessageDal _outgoingMessageDal;

        public OutgoingMessagesManager(IOutgoingMessageDal outgoingMessageDal)
        {
            _outgoingMessageDal = outgoingMessageDal;
        }

        public List<OutgoingMessage> GetOutgoingMessages(int UserID)
        {
            return _outgoingMessageDal.GetList().Where(x => x.UserID == UserID).ToList();
        }

        public void TAdd(OutgoingMessage t)
        {
            _outgoingMessageDal.Insert(t);
        }

        public void TDelete(OutgoingMessage t)
        {
            throw new NotImplementedException();
        }

        public OutgoingMessage TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<OutgoingMessage> TGetList()
        {
            throw new NotImplementedException();
        }

        public List<OutgoingMessage> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(OutgoingMessage t)
        {
            throw new NotImplementedException();
        }
    }
}

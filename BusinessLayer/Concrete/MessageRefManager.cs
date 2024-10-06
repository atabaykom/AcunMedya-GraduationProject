using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageRefManager : IMessageRefService
    {
        IMessageRefDal _IMessageRefDal;

        public MessageRefManager(IMessageRefDal ıMessageRefDal)
        {
            _IMessageRefDal = ıMessageRefDal;
        }

        public void TAdd(MessageRef t)
        {
            _IMessageRefDal.Insert(t);
        }

        public void TDelete(MessageRef t)
        {
            throw new NotImplementedException();
        }

        public MessageRef TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<MessageRef> TGetList()
        {
            return _IMessageRefDal.GetList();
        }

        public List<MessageRef> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(MessageRef t)
        {
            throw new NotImplementedException();
        }
    }
}

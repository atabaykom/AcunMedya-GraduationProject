using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IIncomingMessageService : IGenericService<IncomingMessage>
    {
        public List<IncomingMessage> GetIncomingMessages(int UserID);
        public List<IncomingMessage> GetIncomingMessagesBox(int UserID);
    }
}

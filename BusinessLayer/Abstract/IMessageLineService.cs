using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageLineService:IGenericService<MessageLine>
    {
        List<MessageLine> GetMessages(int MessageID);
        List<MessageLine> GetMessageBoxByUserID(int userID);
        List<MessageLine> GetMessagesDetailByUserID(int userID);
        List<MessageLine> GetMessagesDetailByTwoUserID(int userID,int UserIDTwo,int MessageID);
    }
}

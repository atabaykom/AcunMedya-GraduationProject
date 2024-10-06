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
    public class NotificationManager : INotificationService
    {
        INotificationDal _notification;
        public NotificationManager(INotificationDal notificationDal)
        {
            _notification = notificationDal;
        }

        public void TAdd(Notification t)
        {
            _notification.Insert(t);
        }

        public void TDelete(Notification t)
        {
            _notification.Delete(t);
        }

        public Notification TGetByID(int id)
        {
            return _notification.GetByID(id);
        }

        public List<Notification> TGetList()
        {
            return _notification.GetList();
        }

        public List<Notification> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Notification t)
        {
            _notification.Update(t);
        }
    }
}

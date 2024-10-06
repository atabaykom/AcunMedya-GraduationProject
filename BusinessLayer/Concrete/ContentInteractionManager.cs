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
    public class ContentInteractionManager : IContentInteractionService
    {
        IContentInteractionDal _contentInteraction;

        public ContentInteractionManager(IContentInteractionDal contentInteraction)
        {
            _contentInteraction = contentInteraction;
        }

        public void TAdd(ContentInteraction t)
        {
            _contentInteraction.Insert(t);
        }

        public void TDelete(ContentInteraction t)
        {
            _contentInteraction.Delete(t);
        }

        public ContentInteraction TGetByID(int id)
        {
            return _contentInteraction.GetByID(id);
        }

        public List<ContentInteraction> TGetList()
        {
            return _contentInteraction.GetList();
        }

        public List<ContentInteraction> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(ContentInteraction t)
        {
            _contentInteraction.Update(t);
        }
    }
}

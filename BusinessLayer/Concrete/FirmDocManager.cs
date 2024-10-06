using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class FirmDocManager : IFirmDocService
    {
        IFirmDocDal _firmDocDal;

        public FirmDocManager(IFirmDocDal firmDocDal)
        {
            _firmDocDal = firmDocDal;
        }

        public List<FirmDoc> GetAdIMG(int contentID)
        {
            var imgList = _firmDocDal.GetList().Where(x=>x.ContentID==contentID).Select(x=> new FirmDoc { URL=x.URL}).ToList();
            return imgList;
        }

        public void TAdd(FirmDoc t)
        {
             _firmDocDal.Insert(t);
        }
        public void TDelete(FirmDoc t)
        {
            _firmDocDal.Delete(t);
        }

        public FirmDoc TGetByID(int id)
        {
            return _firmDocDal.GetByID(id);
        }

        public List<FirmDoc> TGetList()
        {
            return _firmDocDal.GetList();
        }

        public List<FirmDoc> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(FirmDoc t)
        {
            _firmDocDal.Update(t);
        }
    }
}

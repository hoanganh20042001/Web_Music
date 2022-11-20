using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Music.Models;

namespace Web_Music.Function
{
    public class FeedDetalDao
    {
        MyDBConect db = null;
        public FeedDetalDao()
        {
            db = new MyDBConect();
        }
        public List<TIN_MOI> ListByCategoryId(string id, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = db.TIN_MOI.Where(x => x.MaTM == id).Count();
            var model = (from a in db.TIN_MOI
                         select new
                         {
                             Title = a.TenTM,
                             CreatedDate = a.ThoiGian,
                             Images = a.URL_img,
                             Link = a.URL_link,
                             Seens = a.LuotTruyCap,
                             Note = a.GhiChu
                         }).AsEnumerable().Select(x => new TIN_MOI()
                         {
                             TenTM = x.Title,
                             ThoiGian = x.CreatedDate,
                             URL_img = x.Images,
                             URL_link = x.Link,
                             LuotTruyCap = x.Seens,
                             GhiChu = x.Note
                         });
            model.OrderByDescending(x => x.ThoiGian).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }
    }
}
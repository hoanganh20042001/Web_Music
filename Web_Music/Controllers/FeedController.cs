using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Music.Common;
using Web_Music.Function;

namespace Web_Music.Controllers
{
    public class FeedController : BaseController
    {
        // GET: Feed
        public ActionResult Index()
        {
            return View();
        }
        public void SetViewBag(int? selectedID = null)
        {
            var dao = new FeedDao();
            ViewBag.MaTM = new SelectList(dao.ListAll(),"MaTM", "TenTM", selectedID );
        }
        public ActionResult Feed(string id, int page = 1, int pageSize = 5)
        {
            var feed = new FeedDao().ViewDetail(id);
            ViewBag.TIN_MOI = feed;
            int totalRecord = 0;
            var model = new FeedDetalDao().ListByCategoryId(id, ref totalRecord);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;

            return View(model);
        }
    }
}
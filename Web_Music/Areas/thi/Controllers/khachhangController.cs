using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Music.Models;

namespace Web_Music.Areas.thi.Controllers
{
    public class khachhangController : Controller
    {
        // GET: thi/khachhang
        MyDBConect db = new MyDBConect();

        public ActionResult Index()
        {
            var list = db.KHACH_HANG.Find(Session["makh"].ToString());
            return View(list);
        }
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(KHACH_HANG model)
        {
            Session["makh"] = model.MaKH;
            db.KHACH_HANG.Add(model);
            db.SaveChanges();
            return View();
        }
        public ActionResult edit( string makh)
        {
            var list = db.KHACH_HANG.Find(Session["makh"].ToString());
            return View(list);
        }
        [HttpPost]
        public ActionResult edit(KHACH_HANG model)
        {
            db.SaveChanges();
            return View();
        }

    }
}
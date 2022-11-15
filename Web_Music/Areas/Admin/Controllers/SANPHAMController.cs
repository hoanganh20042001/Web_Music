using Web_Music.Areas.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Music.Models;
using Web_Music.Function;

namespace Web_Music.Areas.Admin.Controllers
{
    public class SANPHAMController : BaseController
    {
        MyDBConect db = new MyDBConect();
        // GET: Admin/SANPHAM
        public ActionResult Index()
        {
            var list = new SanPhamF().SP();
            //var list = db.SAN_PHAM.ToList();
            ViewBag.list = list;
            return View();
        }
        [HttpPost]
        public ActionResult Index(string ma)
        {
            var list = new SanPhamF().Search(ma);
            //var list = db.SAN_PHAM.ToList();
            ViewBag.list = list;
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
    }
}
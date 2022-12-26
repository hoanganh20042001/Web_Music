using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Music.Function;

namespace Web_Music.Areas.Admin.Controllers
{
    public class BTLController : Controller
    {
        // GET: Admin/BTL
        public ActionResult Index()
        {

            var list = new KhachHangF().ListAll();
            ViewBag.list = list;
            return View(list);
           
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Music.Models;
using Web_Music.Function;
using Web_Music.Areas.Admin.Controllers;

namespace Web_Music.Areas.Admin.Controllers
    
{
    public class TINMOIController : BaseController
    {
        // GET: Admin/TINMOI
        MyDBConect db = new MyDBConect();
        public ActionResult Index()
        {
            var item = db.TIN_MOI.ToList();
            return View(item);
        }
        public ActionResult Detail(string id)
        {
            var item = new TinMoiF();
            //var qs = db.Database.SqlQuery<string>("SELECT max(RIGHT(mans, 8)) FROM nghe_si").SingleOrDefault();
            ////string val = qs.ToString();
            //ViewBag.qs = qs.ToString();
            var result = item.ListBrand(id);
            //ViewBag.img = item.Find(id).URL_img;
            ViewBag.TM = result;
            return View();
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            var item = new TinMoiF();
            var result = item.Find(id);
            if (result == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //var Cate = new CategoryF();
            //ViewBag.Category = Cate.ListAll();
            return View(result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NGHE_SI Model)
        {
            try
            {
                var item = new NgheSiF();
                var result = item.Edit(Model);
                if (result == true) return RedirectToAction("Index");
                else
                {
                    ModelState.AddModelError("", "Edit item Unsucessfully");
                }

                //ViewBag.Category = new SelectList(db.NGHE_SIs.ToList(), "Id", "Name", Model.mans);
                return View(Model);
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(string ID)
        {
            var item = new NgheSiF();
            //var result = item.Find(ID);
            //if (result == null)
            //{
            //    Response.StatusCode = 404;
            //    return null;
            //}
            //return View(result);
            var result = item.Delete(ID);
            return RedirectToAction("Index");
            //if (result == true)
            //    return RedirectToAction("Index");
            //else
            //{
            //    ModelState.AddModelError("", "Edit item Unsucessfully");
            //    return RedirectToAction("Index");
            //}

        }
    }
}
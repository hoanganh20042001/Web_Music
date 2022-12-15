using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Music.Models;
using Web_Music.Function;
using Web_Music.Areas.Admin.Controllers;
using System.IO;

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
            var item = new TinMoiF();
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
        public ActionResult Create()
        {
            TIN_MOI ns = new TIN_MOI();

            return View(ns);
        }
        [HttpPost]


        public ActionResult Create(TIN_MOI Model)
        {
            //var item = new NgheSiF();
            //Model.mans = item.AutoID();
            //db.NGHE_SIs.Add(Model);

            //db.SaveChanges();
            ////if(url_img!=null && url_img.ContentLength > 0)
            ////{
            ////    int id=int.Parse()
            ////}
            //return View(Model);

            try
            {


                var item = new TinMoiF();
                Model.MaTM = item.AutoID();

                if (Model.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(Model.ImageUpload.FileName);
                    string extension = Path.GetExtension(Model.ImageUpload.FileName);
                    Model.URL_img = "~/Assets/img/singer/" + fileName + extension;
                    Model.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Assets/img/singer/"), fileName));
                }
                var result = item.Insert(Model);
                return RedirectToAction("Index");


                //if (url_img!=null && url_img.ContentLength > 0)
                //{
                //    //int id = int.Parse(db.NGHE_SIs.ToList().Last().mans.ToString());
                //    string _FileName = "";
                //    int index = url_img.FileName.IndexOf('.');
                //    //_FileName = "NV" + id.ToString() + "." + url_img.FileName.Substring(index + 1);
                //    _FileName = url_img.FileName.ToString();
                //    string _path=Path.Combine(Server.MapPath("~/Asset/"),_FileName);
                //    url_img.SaveAs(_path);
                //    Model.URL_img = _FileName;
                //    db.SaveChanges();
                //}
                return View();

                //ModelState.AddModelError("", "Insert item Unsucessfully");
            }

            catch
            {
                return View();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Music.Models;
using Web_Music.Function;
using Web_Music.Areas.Admin.Controllers;
using System.IO;
using System.Data.SqlClient;

namespace Web_Music.Areas.Admin.Controllers

{
    public class TINMOIController : BaseController
    {
        // GET: Admin/TINMOI
        MyDBConect db = new MyDBConect();
        public ActionResult Index()

        {
            if (Session["MaAD"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var item = db.TIN_MOI.ToList();
                return View(item);
            }
        }
        public ActionResult Search(string search)

        {
            if (Session["MaAD"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                if (search == "")
                {
                    return RedirectToAction("Index");
                }
                string se = "%" + search + "%";

                var list = db.TIN_MOI.SqlQuery("select * from Tin_Moi where TenTM like @se", new SqlParameter("@se", se)).ToList();
                return View(list);
            }
        }
        public ActionResult Detail(string id)
        {
            if (Session["MaAD"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
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
           
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            if (Session["MaAD"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
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
        }
        [HttpPost]
        
        public ActionResult Edit(TIN_MOI Model)
        {
            //try
            //{
            if (Session["MaAD"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var item = new TinMoiF();
                if (Model.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(Model.ImageUpload.FileName);
                    string extension = Path.GetExtension(Model.ImageUpload.FileName);
                    Model.URL_img = "~/Assets/img/singer/" + fileName + extension;
                    Model.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Assets/img/tin mới/"), fileName));
                }
                var result = item.Edit(Model);
                if (result == true) return RedirectToAction("Index");
                else
                {
                    ModelState.AddModelError("", "Edit item Unsucessfully");
                    return View(Model);
                }

                //ViewBag.Category = new SelectList(db.NGHE_SIs.ToList(), "Id", "Name", Model.mans);

                //}
                //catch
                //{
                //    return View();
                //}
            }
        }


        public ActionResult Delete(string ID)
        {
            if (Session["MaAD"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
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

        }
        public ActionResult Create()
        {
            if (Session["MaAD"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                if (Session["MaAD"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    TIN_MOI ns = new TIN_MOI();

                    return View(ns);
                }
            }
        }


        [HttpPost]
        public ActionResult Create(TIN_MOI Model)
        {
            if (Session["MaAD"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {


                var item = new TinMoiF();
                Model.MaTM = item.AutoID();

                if (Model.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(Model.ImageUpload.FileName);
                    string extension = Path.GetExtension(Model.ImageUpload.FileName);
                    Model.URL_img = "~/Assets/img/singer/" + fileName + extension;
                    Model.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Assets/img/tin mới/"), fileName));
                }
                var result = item.Insert(Model);
                if (result == true) return RedirectToAction("Index");
                else
                {
                    ModelState.AddModelError("", "Edit item Unsucessfully");
                    return View(Model);
                }
            }     
        }
    }
}
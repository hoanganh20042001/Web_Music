using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web_Music.Models;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Web_Music.Function;
using System.Collections.Generic;
using Web_Music.Areas.Admin.Controllers;
using Web_Music.Areas.Admin.Model;


namespace Web_Music.Areas.Admin.Controllers
{
    public class KHACHHANGController : BaseController
    {
        private MyDBConect db = new MyDBConect();

        // GET: Admin/KHACH_HANG
        [HttpGet]
        public ActionResult Index()
        {
            //if (Session["MaAD"] == null)
            //{
            //    return RedirectToAction("Login", "Login");
            //}
            //else
            //{
                var list = new KhachHangF().ListAll();
            ViewBag.list = list;
                return View();
            //}
        }
        [HttpPost]
        public ActionResult Index(string search)
        {
			//if (search == "")
			//{
   //             return RedirectToAction("Index");
   //         }
            var list = new KhachHangF().Search(search);
            ViewBag.list = list;
            return View();
        }

        // GET: Admin/KHACH_HANG/Details/5
        public ActionResult Detail(string id)
        {

            var item = new KhachHangF();
            //var qs = db.Database.SqlQuery<string>("SELECT max(RIGHT(mans, 8)) FROM nghe_si").SingleOrDefault();
            ////string val = qs.ToString();
            //ViewBag.qs = qs.ToString();
            var result = item.ListBrand(id);
            Album al = new Album();
            ViewBag.al = al.DS(id);
            return View(result);
        }

        // GET: Admin/KHACH_HANG/Create
        public ActionResult Create()
        {
            KHACH_HANG kh = new KHACH_HANG();
            return View(kh);
        }

        // POST: Admin/KHACH_HANG/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public ActionResult Create(KHACH_HANG Model, HttpPostedFileBase img)
        {
            //if (ModelState.IsValid)
            //{
            //    if (ModelState.IsValid)
            //    {
            //        //ViewBag.MaNhom = new SelectList(db.NHOMs, "MaNhom", "TenNhom");
            //        var item = new KhachHangF();
            //        Model.MaKH = item.AutoID();

            //        if (Model.ImageUpload != null)
            //        {
            //            string fileName = Path.GetFileNameWithoutExtension(Model.ImageUpload.FileName);
            //            string extension = Path.GetExtension(Model.ImageUpload.FileName);
            //            Model.URL_img = "~/Assets/img/KH/" + fileName + extension;
            //            Model.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Assets/img/KH/"), fileName));
            //        }
            //        var result = item.Insert(Model);
            //        return RedirectToAction("Index");
            //    }
            //    return View();
            //}
            var item = new KhachHangF();
            Model.MaKH = item.AutoID();
            if (Model.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(Model.ImageUpload.FileName);
                string extension = Path.GetExtension(Model.ImageUpload.FileName);
                Model.URL_img = "~/Assets/img/KH/" + fileName + extension;
                Model.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Assets/img/KH/"), fileName + extension));
            }

            var result = item.Insert(Model);
            return RedirectToAction("Index");
        }


        public ActionResult Edit(string id)
        {
            var item = new KhachHangF();
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

        public ActionResult Edit(KHACH_HANG Model)
        {
            //         try
            //{
            var item = new KhachHangF();
            var result = item.Edit(Model);
            if (result == true) return RedirectToAction("Index");
            else
            {
                ModelState.AddModelError("", "Edit item Unsucessfully");
                return View(Model);

            }
            //var id = db.SaveChanges();
            //             if (id > 0) return RedirectToAction("Index");
            //             else return View(Model);
            ////ViewBag.Category = new SelectList(db.NGHE_SIs.ToList(), "Id", "Name", Model.mans);
            //return View(Model);
            //}
            //catch
            //{
            //    return View();
            //}
        }

        public ActionResult Delete(string ID)
        {
            var item = new KhachHangF();
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
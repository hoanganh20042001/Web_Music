using Web_Music.Areas.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Music.Models;
using Web_Music.Function;
using System.IO;
using System.Data.SqlClient;

namespace Web_Music.Areas.Admin.Controllers
{
    public class SANPHAMController : BaseController
    {
        MyDBConect db = new MyDBConect();
        // GET: Admin/SANPHAM
        public ActionResult Index()
        {
            if (Session["MaAD"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var list = new SanPhamF().SP();
                //var list = db.SAN_PHAM.ToList();
                ViewBag.list = list;
                return View(list);
            }
        }
        [HttpPost]
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
                var list = new SanPhamF().Search(search);
                //var list = db.SAN_PHAM.ToList();
                ViewBag.list = list;
                return View(list);
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
                var item = new SanPhamF();
                var result = item.Find(id);
                //ViewBag.singer = item.Search(id);
                ViewBag.singer = db.Database.SqlQuery<string>("select nghedanh from nghe_si ns join trinh_bay tb on ns.mans=tb.mans where masp=@masp", new SqlParameter("@masp", id)).SingleOrDefault().ToString();
                ViewBag.singer_id = db.Database.SqlQuery<string>("select mans from  trinh_bay where masp=@masp", new SqlParameter("@masp", id)).SingleOrDefault().ToString();
                NgheSiF ns = new NgheSiF();
                ViewBag.ns = ns.ListAll();

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

        public ActionResult Edit(SAN_PHAM Model, HttpPostedFileBase fileUpload)
        {
            if (Session["MaAD"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                try
                {
                    var item = new SanPhamF();
                    //var result = item.Edit(Model);

                    if (fileUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(fileUpload.FileName);
                        string extension = Path.GetExtension(fileUpload.FileName);
                        Model.SP_URL =/* "~/Assets/img/KH/" +*/ fileName + extension;
                        fileUpload.SaveAs(Path.Combine(Server.MapPath("~/Assets/mp3/"), fileName + extension));
                    }
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
        }
		public ActionResult test()
		{
			return View();
		}
		[HttpPost]
        public ActionResult test(HttpPostedFileBase fileUpload)
		{
            return View();
		}
        public ActionResult Create()
        {
            if (Session["MaAD"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                SAN_PHAM sp = new SAN_PHAM();
                NgheSiF ns = new NgheSiF();
                ViewBag.ns = ns.ListAll();
                return View(sp);
            }
            
        }
        [HttpPost]
        public ActionResult Create(SAN_PHAM Model, HttpPostedFileBase fileUpload,string mans)
        {
            if (Session["MaAD"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var item = new SanPhamF();
                Model.MaSP = item.AutoID();
                if (fileUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(fileUpload.FileName);
                    string extension = Path.GetExtension(fileUpload.FileName);
                    Model.SP_URL =/* "~/Assets/img/KH/" +*/ fileName + extension;
                    fileUpload.SaveAs(Path.Combine(Server.MapPath("~/Assets/mp3/"), fileName + extension));
                }

                var result = item.Insert(Model);
                if (mans != null)
                {
                    TRINH_BAY tb = new TRINH_BAY();
                    tb.MaNS = mans;
                    tb.MaSP = Model.MaSP;
                    tb.GhiChu = Model.GhiChu;
                    db.TRINH_BAY.Add(tb);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
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
                var item = new SanPhamF();
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
                //ViewBag.NgheSi = result;
                var sp = new SanPhamF();
                var newsp = sp.ListSP(id);
                ViewBag.sp = newsp;
                return View(result);
            }
        }

    }

}
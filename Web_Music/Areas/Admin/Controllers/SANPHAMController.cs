﻿using Web_Music.Areas.Admin.Controllers;
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

        public ActionResult Edit(TIN_MOI Model)
        {
            try
            {
                var item = new TinMoiF();
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


        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Delete(string ID)
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
        public ActionResult Detail(string id)
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

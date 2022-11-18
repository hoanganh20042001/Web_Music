using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Music.Function;
using Web_Music.Models;

namespace Web_Music.Controllers
{
    public class FavoriteController : Controller
    {
        // GET: Favorite
        public ActionResult FavoriteSong()
        {
            if (Session["MaKH"] == null)
            {
                return RedirectToAction("Index", "LoginClient");
            }
            else
            {
                var list = new FavoriteSong().SP(Session["MaKH"].ToString());
                ViewBag.list = list;
                ViewBag.size = list.Count;
                return View();
            }
           
        }
        public ActionResult AddSong(String MaSP)
        {
            MyDBConect db = new MyDBConect();
            YEU_THICH model = new YEU_THICH();
            model.masp = MaSP;
            model.makh = Session["MaKH"].ToString();
            db.YEU_THICH.Add(model);
            db.SaveChanges();
            return RedirectToAction("FavoriteSong", "Favorite");

        }
        public ActionResult DeleteSong(string MaSP)
        {
            MyDBConect db = new MyDBConect();
            //var ab = (from ds in db.DS_SP
            //          where ds.MaAl == Session["MaAl"] && ds.MaSP == MaSP
            //          select ds).FirstOrDefault();
            var sp = db.YEU_THICH.Find(Session["MaKH"], MaSP);
            db.YEU_THICH.Remove(sp);
            db.SaveChanges();
            return RedirectToAction("FavoriteSong", "Favorite");
        }
    }
}
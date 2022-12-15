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
            if (Session["MaKH"] == null)
            {
                return RedirectToAction("Index", "LoginClient");
            }
            else
            {
                MyDBConect db = new MyDBConect();
                YEU_THICH model = new YEU_THICH();
                string makh = Session["MaKH"].ToString();
                model.masp = MaSP;
                model.makh = Session["MaKH"].ToString();
                var list = (from yt in db.YEU_THICH
                            where yt.masp == MaSP && yt.makh == makh
                            select yt).ToList();
                if (list.Count() != 0)
                {
                    return RedirectToAction("FavoriteSong", "Favorite");
                }
                else
                {
                    db.YEU_THICH.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("FavoriteSong", "Favorite");
                }
            }

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
        public ActionResult MenuSP()
        {
            //var list = (from sp in db.SAN_PHAM.ToList()
            //                //            join tb in db.TRINH_BAY.ToList()
            //                //            on sp.masp equals tb.MaNS
            //                //            join ns in db.NGHE_SI.ToList()
            //                //            on tb.MaNS equals ns.mans
            //            select sp).ToList();
            //var list = db.SAN_PHAMs.ToList();
            var list = new SanPhamF().SP();
            int i = 0;
            ViewBag.list = list;
            foreach (var item in list)
            {
                ViewBag.i = item;
                i++;
            }
            ViewBag.size = i;
            //var list = db.SAN_PHAMs.SqlQuery("select * from san_pham").ToList();
            return PartialView();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Web_Music.Function;
using Web_Music.Models;

namespace Web_Music.Controllers
{
    public class AlbumController : Controller
    {
        // GET: Album
      
        public ActionResult Album()

        {

            MyDBConect db = new MyDBConect();
            if (Session["MaKH"] == null)
            {
                return RedirectToAction("Index", "LoginClient");
            }
            else
            {

                //List<ALbum> list = db.ALbums.ToList();
                string makh = Session["MaKH"].ToString();
               var list = (from al in db.ALbums
                         where al.MaKH == makh
                           select al).ToList();
                //var list = db.ALbums.Find(Session["MaKH"]);
                return View(list);
            }
        }
        public ActionResult createAlbum()
        {
            return View(new ALbum());
        }
        [HttpPost]
        public ActionResult createAlbum(ALbum model)
        {
            MyDBConect db = new MyDBConect();
            string makh = Session["MaKH"].ToString();
            model.MaKH = makh;
                db.ALbums.Add(model);
                db.SaveChanges();
            return RedirectToAction("Album", "Album");
            

        }
        public ActionResult Delete(string MaAlbum)
        {
            MyDBConect db = new MyDBConect();
            var ds = (from sp in db.DS_SP
                      where sp.MaAl == MaAlbum
                      select sp).ToList();
            foreach (var i in ds)
            {
                db.DS_SP.Remove(i);
                db.SaveChanges();
            }
            var ab = db.ALbums.Find(MaAlbum);
            db.ALbums.Remove(ab);
            db.SaveChanges();
            return RedirectToAction("Album", "Album");
        }
        public ActionResult listSong(string MaAl)
        {
            // thanh
            MyDBConect db = new MyDBConect();
            Session["MaAl"] = MaAl;
            Session["tenAlbum"] = db.ALbums.Find(MaAl).TenAlbum.ToString();

            var list = new SongInAlbum().SP(MaAl.ToString());
            ViewBag.list = list;
            ViewBag.size = list.Count;
            return View();

        }
        public ActionResult newSong()
        {
            
            var list = new resetSong().SP(Session["MaAl"].ToString());
            ViewBag.list = list;
            ViewBag.size = list.Count;
          


            return View();


        }
        public ActionResult AddToAlbum(String MaSP)
        {

            MyDBConect db = new MyDBConect();
            DS_SP model = new DS_SP();
            model.MaSP = MaSP;
            model.MaAl = Session["MaAl"].ToString();
            db.DS_SP.Add(model);
            db.SaveChanges();
            return RedirectToAction("newSong", "Album");

        }
        public ActionResult DeleteSong(string MaSP)
        {
            MyDBConect db = new MyDBConect();
            //var ab = (from ds in db.DS_SP
            //          where ds.MaAl == Session["MaAl"] && ds.MaSP == MaSP
            //          select ds).FirstOrDefault();
            var sp = db.DS_SP.Find(Session["MaAl"], MaSP);
            db.DS_SP.Remove(sp);
            db.SaveChanges();
            return RedirectToAction("Album", "Album");
        }
        public ActionResult MenuSonginAlbum()
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
        public ActionResult MenuAddSong()
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
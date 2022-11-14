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
       MyDBConect db = new MyDBConect();
        public ActionResult Album()

        {

            List<ALbum> list = db.ALbums.ToList();
            return View(list);
        }
        public ActionResult createAlbum()
        {
            return View(new ALbum());
        }
        [HttpPost]
        public ActionResult createAlbum(ALbum model)
        {
          
            if (db.ALbums.Any(x => x.TenAlbum == model.TenAlbum))
            {
                ViewBag.thongbao = " this album is readly. Create new album!";
                return View();
            }
            else
            {
                db.ALbums.Add(model);
                db.SaveChanges();

                return RedirectToAction("Album", "Album");
            }

        }
        public ActionResult Delete(string MaAlbum)
        {
           
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
            Session["MaAl"] = MaAl;

            var list = new SongInAlbum().SP(MaAl.ToString());
            ViewBag.list = list;
            ViewBag.size = list.Count;
            return View();

        }
        public ActionResult newSong( string MaAl)
        {

            var list = new resetSong().SP(MaAl);
            ViewBag.list = list;
            ViewBag.size = list.Count;
            return View();


        }
        public ActionResult AddToAlbum(String MaSP)
        {
           
            DS_SP model = new DS_SP();
            model.MaSP = MaSP;
            model.MaAl = (string)Session["MaAL"];
            if (db.DS_SP.Any(x => x.MaSP != model.MaSP))
            {
                ViewBag.thongbao = " this song is readly";
                return View("listSong", Session["MaAl"]);

            }
            else
            {

                db.DS_SP.Add(model);
                db.SaveChanges();
                return RedirectToAction("newSong", "Album");
            }
        }
        public ActionResult DeleteSong(string MaSP)
        {
         
            //var ab = (from ds in db.DS_SP
            //          where ds.MaAl == Session["MaAl"] && ds.MaSP == MaSP
            //          select ds).FirstOrDefault();
            var sp = db.DS_SP.Find(Session["MaAl"], MaSP);
            db.DS_SP.Remove(sp);
            db.SaveChanges();
            return RedirectToAction("Album", "Album");
        }

    }
}
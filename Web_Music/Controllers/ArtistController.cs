using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Music.Function;
using Web_Music.Models;

namespace Web_Music.Controllers
{
    public class ArtistController : Controller
    {
        // GET: Artist

        MyDBConect db = new MyDBConect();
        public ActionResult Index()
        {
            if (Session["MaKH"] == null)
            {
                return RedirectToAction("Index", "LoginClient");
            }
            else
            {

                var list = new followArtists().SP(Session["MaKH"].ToString());
                return View(list);
            }
        }
        public ActionResult DetailArtists(string mans)
        {
            if (Session["MaKH"] == null)
            {
                return RedirectToAction("Index", "LoginClient");
            }
            else
            {
                Session["MaNS"] = mans;
                var list = new SongOfArtist().SP(mans.ToString());
                ViewBag.list = list;
                ViewBag.size = list.Count;
                return View();
            }

        }
        public  ActionResult FollowArtist(string mans)
        {
            if (Session["MaKH"] == null)
            {
                return RedirectToAction("Index", "LoginClient");
            }
            else
            {
                THEO_DOI model = new THEO_DOI();
                model.MaNS = mans;
                string makh = Session["MaKH"].ToString();
                model.MaKH = Session["MaKH"].ToString();
                var sp = db.THEO_DOI.Find(Session["MaKH"], mans);
                //var list = (from yt in db.THEO_DOI
                //            where yt.MaNS == mans && yt.MaKH == makh
                //            select yt).ToList();
                if (sp != null)
                {
                    return RedirectToAction("index", "Artist");
                }
                else
                {
                    db.THEO_DOI.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("index", "Artist");
                }
            }

           

        }
        public ActionResult unFollow(string mans)
        {
            if (Session["MaKH"] == null)
            {
                return RedirectToAction("Index", "LoginClient");
            }
            else
            {
                var sp = db.THEO_DOI.Find(Session["MaKH"], mans);
                db.THEO_DOI.Remove(sp);
                db.SaveChanges();
                return RedirectToAction("Index", "Artist");
            }
        }
    }

}
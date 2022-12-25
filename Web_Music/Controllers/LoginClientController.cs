using Model.Dao;
using Web_Music.Models;
using Web_Music.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Music.Function;

namespace Web_Music.Controllers
{
    public class LoginClientController : BaseController
    {
        MyDBConect db = new MyDBConect();
        // GET: LoginClient
        public ActionResult Index()
        {
            if (Session["ID"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Login(LoginClientModel model)
        {
            MyDBConect db = new MyDBConect();
            if (ModelState.IsValid)
            {
                
                var dao = new UserDao();
                var resultKH = dao.Login(model.UserName, Encryptor.MD5Hash(model.PassWord));

                if (resultKH == 2)
                {
                    var userKH = dao.GetBymaKH(model.UserName);
                    var userSessionKH = new UserLogin();
                    //
                    return RedirectToAction("Index", "Home");
                }
                else if (resultKH == 0)
                {
                    ModelState.AddModelError("", "Account is not exist");
                }
                else if (resultKH == -1)
                {
                    ModelState.AddModelError("", "Your account is blocked");
                }
                else if (resultKH == -2)
                {
                    ModelState.AddModelError("", "Password is not correct");
                }
            }
            return View("Index");
        }

        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }
        public ActionResult Edit()
        {
          
                var item = new KhachHangF();
                var result = item.Find(Session["MaKH"].ToString());
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
            if (result == true) return RedirectToAction("Index", "Home");
            else
            {
                Session["TenKH"] = Model.TenKH;
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


    }
}
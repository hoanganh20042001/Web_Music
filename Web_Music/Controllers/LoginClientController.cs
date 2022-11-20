using Model.Dao;
using Web_Music.Models;
using Web_Music.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            if (ModelState.IsValid)
            {
                
                var dao = new UserDao();
                var resultKH = dao.Login(model.UserName, Encryptor.MD5Hash(model.PassWord));

                if (resultKH == 2)
                {
                    var userKH = dao.GetBymaKH(model.UserName);
                    var userSessionKH = new UserLogin();
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

    }
}
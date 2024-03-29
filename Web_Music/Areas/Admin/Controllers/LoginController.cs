﻿using Web_Music.Areas.Admin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Music.Common;
using Model.Dao;

namespace Web_Music.Areas.Admin.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                UserDao dao = new UserDao();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.PassWord));
                if (result == 1)
                {
                    var user = dao.GetBymaKH(model.UserName);
                    var userSession = new UserLogin();
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "KHACHHANG");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Account is not exist");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Your account is blocked");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Password is not correct");
                }
            }
            return View("Index");
        }
    }
}
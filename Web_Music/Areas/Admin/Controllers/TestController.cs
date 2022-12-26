using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Web_Music.Models;
using Web_Music.Function;
namespace Web_Music.Areas.Admin.Controllers
{
    public class TestController : Controller
    {
        // GET: Admin/Test
        public ActionResult Index()
        { var data = 1;
            return PartialView("Context", data);
        }
       
        public ActionResult Context()
		{
            string user = Request.QueryString["user"];
            return View();
		}
        
        public ActionResult Context1(string id)
        {
            string user = Request.QueryString["user"];
            ViewBag.id = id;
            return View();
        }
        public ActionResult par()
		{
            return PartialView();
		}
        public ActionResult app()
		{
            Response.Write("<h1>Response Demo by hiepsiit.com</h1>");
            //ViewBag.app = HttpContext.Application["num"];
            return View();
		}
        public ActionResult testAIP()
		{
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44364/");
            client.DefaultRequestHeaders.Accept.Add(new
           MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("api/KH").Result;
            if (response.IsSuccessStatusCode)
            {
                var model =
               response.Content.ReadAsAsync<IEnumerable<KhachHang>>().Result;
                return View(model);
            }
            return View();
        }
    }
}
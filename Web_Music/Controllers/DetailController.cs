using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_Music.Models;
using Web_Music.Function;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Web_Music.Controllers
{
    public class DetailController : ApiController
    {
        // GET: api/Detail
        MyDBConect db = new MyDBConect();
        public IEnumerable<SP> Get()
        {
            var model = db.SAN_PHAM.Select(p => new SP()
            {
                MaSP = p.MaSP,
                TenSP = p.TenSP,
                SP_URL = p.SP_URL
            }).ToList();
            return model;
        }

        // GET: api/Detail/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Detail
        public IHttpActionResult Post(SAN_PHAM sp)
        {
            if (!ModelState.IsValid)
                return BadRequest("Ivalid data.");
            var ne = db.SAN_PHAM.Add(new SAN_PHAM()
            {
                MaSP = sp.MaSP
            });
            db.SaveChanges();
            return Ok();
        }
       
        // PUT: api/Detail/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Detail/5
        public void Delete(int id)
        {
        }
        //public ActionResult Detail(int id)
        //{
        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri("https://localhost:44399/");
        //    client.DefaultRequestHeaders.Accept
        //    .Add(new
        //    MediaTypeWithQualityHeaderValue("application/json"));
        //    HttpResponseMessage response =
        //    client.GetAsync("api/product/" + id).Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var model = JsonConvert.DeserializeObject<SP>(response
        //        .Content.ReadAsStringAsync().Result);
        //        return View("Detail", model);
        //    }
        //    return View("Detail");
        //}
    }
}

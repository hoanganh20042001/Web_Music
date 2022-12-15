using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Music.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace Web_Music.Function
{
    public class AlbumF
    {
        MyDBConect db = new MyDBConect();

        public List<ALbum> ListAll()
        {
            var result = db.ALbums.ToList();
            return result;
        }
        public int Count()
        {
            int value = db.Database.SqlQuery<int>("SELECT count(*) FROM Album").SingleOrDefault();
            return value;
        }
        public ALbum ListBrand(string ID)
        {
            var result = db.ALbums.Where(p => p.MaAl == ID).SingleOrDefault();
            return result;
        }
        public string AutoID()
        {
            string result;
            //string values = db.NGHE_SIs.SqlQuery("SELECT max(RIGHT(MAns, 8)) FROM nghe_si").SingleOrDefault().ToString();
            int value = int.Parse(db.Database.SqlQuery<string>("SELECT max(RIGHT(MAns, 8)) FROM Album").SingleOrDefault().ToString());
            if (0 <= value && value < 9)
            {
                result = "Al0000000" + Convert.ToString(value + 1);
            }
            else if (9 <= value && value < 99)
            {
                result = "Al000000" + Convert.ToString(value + 1);
            }
            else if (99 <= value && value < 999)
            {
                result = "Al00000" + Convert.ToString(value + 1);
            }
            else if (999 <= value && value < 9999)
            {
                result = "Al0000" + Convert.ToString(value + 1);
            }
            else if (9999 <= value && value < 99999)
            {
                result = "Al000" + Convert.ToString(value + 1);
            }
            else if (99999 <= value && value < 999999)
            {
                result = "Al00" + Convert.ToString(value + 1);
            }

            else
            {
                result = "Al0" + Convert.ToString(value + 1);
            }
            return result;
        }
        public bool Insert(ALbum Model)
        {
            var result = db.ALbums.Find(Model.MaAl);

            if (result != null)
            {
                return false;
            }
            else
            {
                db.ALbums.Add(Model);
                db.SaveChanges();
                return true;
            }
        }
        public ALbum Find(string id)
        {
            var result = db.ALbums.Find(id);
            return result;
        }
        //public bool Edit(NGHE_SI Model)
        //{
        //    var result = db.NGHE_SI.Find(Model.mans);
        //    if (result != null)
        //    {
        //        result.mans = Model.mans;
        //        result.TenNS = Model.TenNS;
        //        result.GT = Model.GT;
        //        result.URL_img = Model.URL_img;
        //        result.QueQuan = Model.QueQuan;

        //        result.NS_URL = Model.NS_URL;
        //        result.NgheDanh = Model.NgheDanh;
        //        db.SaveChanges();
        //        return true;
        //    }
        //    else return true;
        //}
        //public bool Delete(string id)
        //{
        //    var result = db.NGHE_SI.Find(id);
        //    if (result != null)
        //    {
        //        db.NGHE_SI.Remove(result);
        //        db.SaveChanges();
        //        return true;
        //    }
        //    else return false;
        //}

    }
}
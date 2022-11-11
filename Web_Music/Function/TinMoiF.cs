using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Music.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace Web_Music.Function
{
    public class TinMoiF
    {
        MyDBConect db = new MyDBConect();

        public List<TIN_MOI> ListAll()
        {
            var result = db.TIN_MOI.ToList();
            return result;
        }
        public int Count()
        {
            int value = db.Database.SqlQuery<int>("SELECT count(*) FROM tin_moi").SingleOrDefault();
            return value;
        }
        public TIN_MOI ListBrand(string ID)
        {
            var result = db.TIN_MOI.Where(p => p.MaTM == ID).SingleOrDefault();
            return result;
        }
        public string AutoID()
        {
            string result;
            //string values = db.NGHE_SIs.SqlQuery("SELECT max(RIGHT(MAns, 8)) FROM nghe_si").SingleOrDefault().ToString();
            int value = int.Parse(db.Database.SqlQuery<string>("SELECT max(RIGHT(MAns, 8)) FROM tin_moi").SingleOrDefault().ToString());
            if (0 <= value && value < 9)
            {
                result = "TM0000000" + Convert.ToString(value + 1);
            }
            else if (9 <= value && value < 99)
            {
                result = "TM000000" + Convert.ToString(value + 1);
            }
            else if (99 <= value && value < 999)
            {
                result = "TM00000" + Convert.ToString(value + 1);
            }
            else if (999 <= value && value < 9999)
            {
                result = "TM0000" + Convert.ToString(value + 1);
            }
            else if (9999 <= value && value < 99999)
            {
                result = "TM000" + Convert.ToString(value + 1);
            }
            else if (99999 <= value && value < 999999)
            {
                result = "TM00" + Convert.ToString(value + 1);
            }

            else
            {
                result = "TM0" + Convert.ToString(value + 1);
            }
            return result;
        }
        public bool Insert(TIN_MOI Model)
        {
            var result = db.NGHE_SI.Find(Model.MaTM);

            if (result != null)
            {
                return false;
            }
            else
            {
                db.TIN_MOI.Add(Model);
                db.SaveChanges();
                return true;
            }
        }
        public TIN_MOI Find(string id)
        {
            var result = db.TIN_MOI.Find(id);
            return result;
        }
        public bool Edit(TIN_MOI Model)
        {
            var result = db.TIN_MOI.Find(Model.MaTM);
            if (result != null)
            {
                result.MaTM = Model.MaTM;
                result.TenTM = Model.TenTM;
                result.LuotTruyCap = Model.LuotTruyCap;
                result.URL_img = Model.URL_img;
                result.URL_link = Model.URL_link;

                result.ThoiGian = Model.ThoiGian;
                result.GhiChu = Model.GhiChu;
                db.SaveChanges();
                return true;
            }
            else return true;
        }
        public bool Delete(string id)
        {
            var result = db.TIN_MOI.Find(id);
            if (result != null)
            {
                db.TIN_MOI.Remove(result);
                db.SaveChanges();
                return true;
            }
            else return false;
        }
    }
}
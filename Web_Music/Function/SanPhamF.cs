using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Music.Models;
namespace Web_Music.Function
{
    public class SanPhamF

    {
        MyDBConect db = new MyDBConect();
        List<BaiHatF> ListAll = new List<BaiHatF>();
        public List<BaiHatF> SP()
        {
            List<string> masp = new List<string>();
            masp = db.Database.SqlQuery<string>("select masp from san_pham").ToList();
            //BaiHatF bh = new BaiHatF();
            int sum = db.Database.SqlQuery<int>("select count(masp) from san_pham").SingleOrDefault();
            //int value = int.Parse(db.Database.SqlQuery<string>("SELECT max(RIGHT(MAsp, 8)) FROM san_pham").SingleOrDefault().ToString());
            foreach(string item in masp)
            {
                BaiHatF bh = new BaiHatF();
               int index = int.Parse(db.Database.SqlQuery<string>("SELECT RIGHT(MAsp, 8) FROM san_pham where masp=@masp", new SqlParameter("@masp", item)).FirstOrDefault().ToString());
                bh.stt = index - 1;
                bh.Time = db.Database.SqlQuery<TimeSpan>("select thoigian FROM san_pham where masp=@masp", new SqlParameter("@masp", item)).FirstOrDefault().ToString().Substring(4);

                bh.SP = db.SAN_PHAM.Find(item);
                List<string> casi = new List<string>();
                casi = db.Database.SqlQuery<string>("select nghedanh from nghe_si ns join trinh_bay tb on tb.mans=ns.mans where masp=@masp", new SqlParameter("@masp", item)).ToList();
                bh.number = index.ToString();
                foreach(string i in casi)
                {
                    if (bh.TrinhBay == "")
                    {
                        bh.TrinhBay = i;
                    }
                    else
                    bh.TrinhBay = bh.TrinhBay + "," + i;
                }
                ListAll.Add(bh);
            }
            return ListAll;
        }
        public List<BaiHatF> Search(string Ma)
        {
            string value = "N"+"'%" + Ma + "%'";
            List<string> masp = new List<string>();
            masp = db.Database.SqlQuery<string>("select masp from san_pham /*sp join trinh_bay tb on tb.masp=sp.masp join nghe_si ns on ns.mans=tb.mans */where tensp like @value /*or nghedanh like @value*/ ", new SqlParameter("@value", value)).ToList();
            foreach (string item in masp)
            {
                BaiHatF bh = new BaiHatF();
                int index = int.Parse(db.Database.SqlQuery<string>("SELECT RIGHT(MAsp, 8) FROM san_pham where masp=@masp", new SqlParameter("@masp", item)).FirstOrDefault().ToString());
                bh.stt = index - 1;
                bh.Time = db.Database.SqlQuery<TimeSpan>("select thoigian FROM san_pham where masp=@masp", new SqlParameter("@masp", item)).FirstOrDefault().ToString().Substring(4);

                bh.SP = db.SAN_PHAM.Find(item);
                List<string> casi = new List<string>();
                casi = db.Database.SqlQuery<string>("select nghedanh from nghe_si ns join trinh_bay tb on tb.mans=ns.mans where masp=@masp", new SqlParameter("@masp", item)).ToList();
                bh.number = index.ToString();
                foreach (string i in casi)
                {
                    if (bh.TrinhBay == "")
                    {
                        bh.TrinhBay = i;
                    }
                    else
                        bh.TrinhBay = bh.TrinhBay + "," + i;
                }
                ListAll.Add(bh);
            }
            return ListAll;
        }
        public List<SAN_PHAM> ListSP(string id)
        {
            var list = db.SAN_PHAM.SqlQuery("select sp.* FROM san_pham sp join trinh_bay tb on sp.masp=tb.masp where sp.masp=@masp", new SqlParameter("@masp", id)).ToList();
            return list;
        }
        public List<SAN_PHAM> ListAll1()
        {
            var result = db.SAN_PHAM.ToList();
            return result;
        }
        public int Count()
        {
            int value = db.Database.SqlQuery<int>("SELECT count(*) FROM SAN_PHAM").SingleOrDefault();
            return value;
        }
        public SAN_PHAM ListBrand(string ID)
        {
            var result = db.SAN_PHAM.Where(p => p.MaSP == ID).SingleOrDefault();
            return result;
        }
        public bool Insert(SAN_PHAM Model)
        {
            var result = db.SAN_PHAM.Find(Model.MaSP);

            if (result != null)
            {
                return false;
            }
            else
            {
                db.SAN_PHAM.Add(Model);
                db.SaveChanges();
                return true;
            }
        }
        public SAN_PHAM Find(string id)
        {
            var result = db.SAN_PHAM.Find(id);
            return result;
        }
        public bool Edit(SAN_PHAM Model)
        {
            var result = db.SAN_PHAM.Find(Model.MaSP);
            if (result != null)
            {
                //result.MaSP = Model.MaSP;
                //result.TenSP = Model.TenSP;
                //result.SangTac = Model.SangTac;
                //result.URL_img = Model.URL_img;
                //result.QueQuan = Model.QueQuan;

                //result.NS_URL = Model.NS_URL;
                //result.NgheDanh = Model.NgheDanh;
                result = Model;
                db.SaveChanges();
                return true;
            }
            else return true;
        }
        public bool Delete(string id)
        {
            var result = db.SAN_PHAM.Find(id);
            if (result != null)
            {
                db.SAN_PHAM.Remove(result);
                db.SaveChanges();
                return true;
            }
            else return false;
        }

    }
}
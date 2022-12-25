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
        public string AutoID()
        {
            string result;
            //string values = db.KHACH_HANGs.SqlQuery("SELECT max(RIGHT(MAns, 8)) FROM SAN_PHAM").SingleOrDefault().ToString();
            int value = int.Parse(db.Database.SqlQuery<string>("SELECT max(RIGHT(MAsp, 8)) FROM SAN_PHAM").SingleOrDefault().ToString());
            if (0 <= value && value < 9)
            {
                result = "SP0000000" + Convert.ToString(value + 1);
            }
            else if (9 <= value && value < 99)
            {
                result = "SP000000" + Convert.ToString(value + 1);
            }
            else if (99 <= value && value < 999)
            {
                result = "SP00000" + Convert.ToString(value + 1);
            }
            else if (999 <= value && value < 9999)
            {
                result = "SP0000" + Convert.ToString(value + 1);
            }
            else if (9999 <= value && value < 99999)
            {
                result = "SP000" + Convert.ToString(value + 1);
            }
            else if (99999 <= value && value < 999999)
            {
                result = "SP00" + Convert.ToString(value + 1);
            }

            else
            {
                result = "SP0" + Convert.ToString(value + 1);
            }
            return result;
        }
        List<BaiHatF> ListAll = new List<BaiHatF>();
        public List<BaiHatF> SP()
        {
            List<string> masp = new List<string>();
            masp = db.Database.SqlQuery<string>("select masp from san_pham where trangthai=1").ToList();
            //BaiHatF bh = new BaiHatF();
          //  int sum = db.Database.SqlQuery<int>("select count(masp) from san_pham").SingleOrDefault();
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
                bh.MaSP = item.ToString();

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
        /*sp join trinh_bay tb on tb.masp=sp.masp join nghe_si ns on ns.mans=tb.mans */
        /*or nghedanh like @value*/
        public List<BaiHatF> Search(string Ma)
        {
            if (Ma !="")
            {
                string value = "%" + Ma + "%";
                List<string> masp = new List<string>();
                masp = db.Database.SqlQuery<string>("select sp.masp from san_pham sp join trinh_bay tb on tb.masp=sp.masp join nghe_si ns on ns.mans=tb.mans where tensp like @value or nghedanh like @value ", new SqlParameter("@value", value)).ToList();
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
            else
            {
                var list = new SanPhamF();

                return list.SP();
            }
        }
        public List<SAN_PHAM> ListSP(string id)
        {
            var list = db.SAN_PHAM.SqlQuery("select tensp,sangtac,sp_url,theloai,trangthai,luotnghe,sp.GhiChu,yeuthich,khongyeuthich,tgphathanh,sp.masp,thoigian FROM san_pham sp join trinh_bay tb on sp.masp=tb.masp where mans=@mans", new SqlParameter("@mans", id)).ToList();
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
				result.MaSP = Model.MaSP;
				result.TenSP = Model.TenSP;
				result.SangTac = Model.SangTac;
				result.SP_URL = Model.SP_URL;
				result.TGPhatHanh = Model.TGPhatHanh;

				result.Theloai = Model.Theloai;
				result.ThoiGian = Model.ThoiGian;
                result.TrangThai = Model.TrangThai;
                result.YeuThich = Model.YeuThich;
				//result = Model;
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
                //db.SAN_PHAM.Remove(result);
                result.TrangThai = false;
                db.SaveChanges();
                return true;
            }
            else return false;
        }

    }
}
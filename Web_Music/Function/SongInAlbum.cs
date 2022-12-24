using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Music.Models;
namespace Web_Music.Function
{
    public class SongInAlbum

    {
        MyDBConect db = new MyDBConect();
        List<BaiHatF> ListAll = new List<BaiHatF>();
        public List<BaiHatF> SP(string MaAl)
        {
            
            List<string> masp = new List<string>();
            masp = db.Database.SqlQuery<string>("select masp from DS_SP where MaAl=@MaAl",new SqlParameter("@MaAl",MaAl)).ToList();
            //BaiHatF bh = new BaiHatF();
            int sum = db.Database.SqlQuery<int>("select count(masp) from san_pham").SingleOrDefault();
            //int value = int.Parse(db.Database.SqlQuery<string>("SELECT max(RIGHT(MAsp, 8)) FROM san_pham").SingleOrDefault().ToString());
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
        public List<BaiHatF> Search(string Ma,string MaAl)
        {
            if (Ma != "")
            {
                string value = "%" + Ma + "%";
                List<string> masp = new List<string>();
                masp = db.Database.SqlQuery<string>("select sp.masp from san_pham sp join trinh_bay tb on tb.masp=sp.masp join nghe_si ns on ns.mans=tb.mans where tensp like @value or nghedanh like @value  and sp.masp in (select masp from DS_SP where MaAl=@MaAl )", new SqlParameter("@value", value), new SqlParameter("@MaAl",MaAl)).ToList();
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
            else
            {
                var list = new SongInAlbum();

                return list.SP(MaAl);
            }
        }
    }
}
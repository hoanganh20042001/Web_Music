using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Web_Music.Models;

namespace Web_Music.Areas.Admin.Model
{
    public class Album
    {
        MyDBConect db = new MyDBConect();
        public string TenKH { get; set; }
        public string URL_img { set; get; }
        public string TenAL { set; get; }
        public string BH { set; get; }
        public Album()
        {

        }
        public Album(string TenKH, string URL_img, string TenAL, string BH)
        {
            this.TenKH = TenKH;
            this.TenAL = TenAL;
            this.URL_img = URL_img;
            this.BH = BH;

        }
        public List<Album> DS(string id)
        {
            List<Album> list = new List<Album>();
            List<string> maal = new List<string>();
            maal = db.Database.SqlQuery<string>("select maal from khach_hang kh join album al on kh.makh=al.makh where kh.makh=@id", new SqlParameter("@id", id)).ToList();
            foreach (string item in maal)
            {
                Album al = new Album();
                al.TenKH = db.Database.SqlQuery<string>("select tenKh from khach_hang  where makh=@id", new SqlParameter("@id", id)).SingleOrDefault();
                al.TenAL = db.Database.SqlQuery<string>("select tenalbum from album  where maal=@maal", new SqlParameter("@maal", item)).SingleOrDefault();
                al.URL_img = db.Database.SqlQuery<string>("select url_img from khach_hang  where makh=@id", new SqlParameter("@id", id)).SingleOrDefault();
                List<string> bh = new List<string>();
                bh = db.Database.SqlQuery<string>("select tensp from ds_sp ds join san_pham sp on ds.masp=sp.masp where maal=@maal", new SqlParameter("@maal", item)).ToList();
                foreach (string i in bh)
                {
                    if (al.BH == "")
                    {
                        al.BH = i;

                    }
                    else
                        al.BH = al.BH + ", " + i;
                }
                list.Add(al);
            }
            return list;
        }

    }
}
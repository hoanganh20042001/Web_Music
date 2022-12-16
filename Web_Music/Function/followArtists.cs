using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Music.Models;
namespace Web_Music.Function
{
    public class followArtists

    {
        MyDBConect db = new MyDBConect();
        List<NGHE_SI> ListAll = new List<NGHE_SI>();
        public List<NGHE_SI> SP(string Makh)
        {

            List<string> mans = new List<string>();
            ListAll = db.Database.SqlQuery<NGHE_SI>("select * from nghe_si where mans   in (select mans  from Theo_doi  where makh=@makh)", new SqlParameter("@makh", Makh)).ToList();
            //BaiHatF bh = new BaiHatF();
           
           
            return ListAll;
        }

    }
}
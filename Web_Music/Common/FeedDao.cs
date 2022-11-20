using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Web_Music.Models;

namespace Web_Music.Common
{
    public class FeedDao
    {
        MyDBConect db = new MyDBConect();
        public List<TIN_MOI> ListAll()
        {
            //var connecString = ConfigurationManager.ConnectionStrings["MyDBConect"].ToString();
            
            return db.TIN_MOI.ToList();
        }
        public TIN_MOI ViewDetail(string id)
        {
            return db.TIN_MOI.Find(id);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Music.Models
{
    public class FeedModel
    {
        public string MaTM { get; set; }
        public string TenTM { get; set; }
        public DateTime ThoiGian { get; set }
        public string GhiChu { get; set; }
        public int LuotTruyCap
        {
            get; set;
        }
        public string URL_img { get; set; }
        public string URL_link
        {
            get; set;
        }
    public List<FeedModel> DanhSach()
        {
            var listkq = new List<FeedModel>();
            FeedModel feed1 = new FeedModel();
            feed1.MaTM = "TM00000001";
            feed1.TenTM = ""

            return new List<FeedModel>();
        }
    }
}
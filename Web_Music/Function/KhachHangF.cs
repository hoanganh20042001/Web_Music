using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Music.Models;
using System.Data.SqlClient;

namespace Web_Music.Function
{
    public class KhachHangF
    {
        MyDBConect db = new MyDBConect();
        public string AutoID()
        {
            string result;
            //string values = db.KHACH_HANGs.SqlQuery("SELECT max(RIGHT(MAns, 8)) FROM KHACH_HANG").SingleOrDefault().ToString();
            int value = int.Parse(db.Database.SqlQuery<string>("SELECT max(RIGHT(MAKH, 8)) FROM khach_hang").SingleOrDefault().ToString());
            if (0 <= value && value < 9)
            {
                result = "KH0000000" + Convert.ToString(value + 1);
            }
            else if (9 <= value && value < 99)
            {
                result = "KH000000" + Convert.ToString(value + 1);
            }
            else if (99 <= value && value < 999)
            {
                result = "KH00000" + Convert.ToString(value + 1);
            }
            else if (999 <= value && value < 9999)
            {
                result = "KH0000" + Convert.ToString(value + 1);
            }
            else if (9999 <= value && value < 99999)
            {
                result = "KH000" + Convert.ToString(value + 1);
            }
            else if (99999 <= value && value < 999999)
            {
                result = "KH00" + Convert.ToString(value + 1);
            }

            else
            {
                result = "KH0" + Convert.ToString(value + 1);
            }
            return result;
        }
        public List<KHACH_HANG> ListAll()
        {
            var result = db.Database.SqlQuery<KHACH_HANG>("select * from khach_hang where trangthai='true' ").ToList();
            return result;
        }
        public List<KHACH_HANG> Search(string search)
        {
            string value = "%" +search + "%";
            var list = db.Database.SqlQuery<KHACH_HANG>("select * from khach_hang where trangthai='true' and tenkh like @value", new SqlParameter("@value", value)).ToList();
            return list;
        }
        public int Count()
        {
            int value = db.Database.SqlQuery<int>("SELECT count(*) FROM KHACH_HANG where trangthai='true'").SingleOrDefault();
            return value;
        }
        public KHACH_HANG ListBrand(string ID)
        {
            var result = db.KHACH_HANG.Where(p => p.MaKH == ID).SingleOrDefault();
            return result;
        }
        public bool Insert(KHACH_HANG Model)
        {
            var result = db.KHACH_HANG.Find(Model.MaKH);

            if (result != null)
            {
                return false;
            }
            else
            {
                db.KHACH_HANG.Add(Model);
                db.SaveChanges();
                return true;
            }
        }
        public KHACH_HANG Find(string id)
        {
            var result = db.KHACH_HANG.Find(id);
            return result;
        }
        public bool Edit(KHACH_HANG Model)
        {
            var result = db.KHACH_HANG.Find(Model.MaKH);
            if (result != null)
            {
				//result = Model;
				result.MaKH = Model.MaKH;
				result.TenKH = Model.TenKH;
				result.GT = Model.GT;
				result.URL_img = Model.URL_img;
				result.DiaChi = Model.DiaChi;
				result.CCCD = Model.CCCD;
				result.Email = Model.Email;
				result.GhiChu = Model.GhiChu;
				result.NgaySinh = Model.NgaySinh;
				result.UserName = Model.UserName;
                result.Pass = Model.Pass;
                result.TrangThai = Model.TrangThai;

				db.SaveChanges();
                return true;
            }
            else return true;
        }
        public bool Delete(string id)
        {
            var result = db.KHACH_HANG.Find(id);
            if (result != null)
            {
                //db.KHACH_HANG.Remove(result);
                result.TrangThai = false;
                db.SaveChanges();
                return true;
            }
            else return false;
        }
    }
}
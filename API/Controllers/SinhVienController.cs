using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Models;

namespace API.Controllers
{
    public class SinhVienController : ApiController 
    {

        private ConnectSever con = new ConnectSever();
        // GET api/<controller>
        [HttpGet]
        [Route("api/dssinhvien")]
        public List<SinhVienModel> DanhSachSinhVien()
        {
            con.OpenConnection();
            List<SinhVienModel> ls = new List<SinhVienModel>();

            SqlCommand cm = new SqlCommand();
            cm.CommandText = "Select * From dbo.sinh_vien";

            cm.Connection = con.sqlCon;

            var a = cm.ExecuteReader();

            while (a.Read())
            {
                SinhVienModel sv = new SinhVienModel();
                sv.Ma_sv = a[0].ToString();
                sv.ho_dem = a[1].ToString();
                sv.ten = a[2].ToString();
                sv.gioi_tinh = Convert.ToByte(a[3]);
                sv.ngay_sinh = Convert.ToDateTime(a[4]);
                sv.ghi_chu = a[5].ToString();

                ls.Add(sv);

            }
            con.CloseConnection();

            return ls;
        }


       

    }
}
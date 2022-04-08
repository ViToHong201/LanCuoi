using API.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class LopHocPhanController : ApiController
    {
        private ConnectSever con = new ConnectSever();

        [HttpGet]
        [Route("api/dslophocphan")]
        public List<LopHocPhanModel> DsLopHocPhan()
        {
            con.OpenConnection();

            List<LopHocPhanModel> ls = new List<LopHocPhanModel>();

            SqlCommand cm = new SqlCommand();
            cm.CommandText = "Select * From dbo.lop_hoc_phan";
            cm.Connection = con.sqlCon;
            var a = cm.ExecuteReader();

            while (a.Read())
            {
                LopHocPhanModel lhp = new LopHocPhanModel();

                lhp.lhp_key_id = a[0].ToString();
                lhp.lhp_ma_lhp = a[1].ToString();
                lhp.lhp_lop_hoc = a[2].ToString();
                lhp.lhp_ten_mon_hoc = a[3].ToString();
                lhp.lhp_nam_hk = a[4].ToString();

                ls.Add(lhp);
            }
            con.CloseConnection();
            return ls;
        }
    }
}
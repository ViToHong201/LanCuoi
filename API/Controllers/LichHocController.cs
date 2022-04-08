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
    public class LichHocController : ApiController
    {
        private ConnectSever con = new ConnectSever();

        [HttpGet]
        [Route("api/lichhoc/{ma_sv}")]
        public List<LichHocCuaSinhVien> LichHocSinhVien(string ma_sv)
        {
            con.OpenConnection();

            List<LichHocCuaSinhVien> ls = new List<LichHocCuaSinhVien>();
           

            SqlCommand cm = new SqlCommand();
            cm.CommandText = @"
                                select  *
                                from sinh_vien sv, sinh_vien_lop_hoc_phan svlhp,lop_hoc_phan lhp, lich_hoc lh, tuan_hoc th
                                where svlhp.svlhp_nhom = lh.lh_nhom and sv.sv_ma_sv = svlhp.sv_ma_sv and svlhp.lhp_key_id = lhp.lhp_key_id and lh.lhp_key_id = lhp.lhp_key_id and th.lh_id = lh.lh_id and sv.sv_ma_sv = @Ma_Sv
                               " ;
            cm.Parameters.Add(new SqlParameter("Ma_Sv",ma_sv));
            cm.Connection = con.sqlCon;
            var a = cm.ExecuteReader();

            while (a.Read())
            {
                LichHocCuaSinhVien lh = new LichHocCuaSinhVien();
              

                lh.Ma_sv = a[0].ToString();
                lh.ho_dem = a[1].ToString();
                lh.ten = a[2].ToString();
                lh.gioi_tinh = Convert.ToByte(a[3]);
                lh.ngay_sinh = Convert.ToDateTime(a[4]);
                lh.ghi_chu = a[5].ToString();
                
                lh.svlhp_nhom = Convert.ToByte(a[9]);
                
                lh.lhp_ma_lhp = a[11].ToString();
                lh.lhp_lop_hoc = a[12].ToString();
                lh.lhp_ten_mon_hoc = a[13].ToString();
                lh.lhp_nam_hk = a[14].ToString();

                lh.lh_tiet = a[16].ToString();
                lh.lh_ngay_bat_dau = Convert.ToDateTime(a[18]);
                lh.lh_phong = a[19].ToString();
                lh.lh_giang_vien = a[20].ToString();
                lh.lh_ghi_chu = a[21].ToString();

                lh.th_tuan = a[24].ToString();

                ls.Add(lh);
          
            }
            con.CloseConnection();
            return ls;
        }

        [HttpGet]
        [Route("api/lichday/{ma_gv}")]
        public List<LichDay_GiangVien> DsLopHocPhan(string ma_gv)
        {
            con.OpenConnection();

            List<LichDay_GiangVien> ls = new List<LichDay_GiangVien>();


            SqlCommand cm = new SqlCommand();
            cm.CommandText = @"
                                select distinct th.th_tuan,lh.lh_tiet, lh.lh_nhom, lh.lh_phong, lh.lh_ngay_bat_dau ,lh.lh_ghi_chu, gv.gv_ho_ten,gv.gv_ghi_chu, lhp.lhp_ten_mon_hoc, lhp.lhp_nam_hk, a.si_so
                                from	lich_hoc lh, giang_vien gv, giang_vien_lop_hoc_phan gvlhp, lop_hoc_phan lhp, tuan_hoc th, sinh_vien sv, sinh_vien_lop_hoc_phan svlhp, 
                                (
		                                select svl.lhp_key_id, svl.svlhp_nhom, count(svl.lhp_key_id) as si_so
		                                from sinh_vien_lop_hoc_phan svl
		                                group by svl.lhp_key_id, svl.svlhp_nhom
                                ) as a
                                where	lhp.lhp_key_id = gvlhp.lhp_key_id and gv.gv_id = gvlhp.gv_id and lhp.lhp_key_id = lh.lhp_key_id and th.lh_id = lh.lh_id and a.lhp_key_id = lhp.lhp_key_id and a.svlhp_nhom = lh.lh_nhom and gv.gv_id  = @Ma_gv
                            ";
            cm.Parameters.Add(new SqlParameter("Ma_gv", ma_gv));
            cm.Connection = con.sqlCon;
            var a = cm.ExecuteReader();

            while (a.Read())
            {
                LichDay_GiangVien lh = new LichDay_GiangVien();

                lh.th_tuan = a[0].ToString();
                lh.lh_tiet = a[1].ToString();
                lh.lh_nhom = Convert.ToByte(a[2]);
                lh.lh_phong = a[3].ToString();
                lh.lh_ngay_bat_dau = Convert.ToDateTime(a[4]);
                lh.lh_ghi_chu = a[5].ToString();
                lh.gv_ho_ten = a[6].ToString();
                lh.gv_ghi_chu = a[7].ToString();
                lh.lhp_ten_mon_hoc = a[8].ToString();
                lh.lhp_nam_hk = a[9].ToString();
                lh.si_so = a[10].ToString();


                ls.Add(lh);

            }
            con.CloseConnection();
            return ls;
        }
    }
}
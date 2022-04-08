using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class LichHocCuaSinhVien
    {
        public string Ma_sv { get; set; }
        public string ho_dem { get; set; }
        public string ten { get; set; }
        public int gioi_tinh { get; set; }
        public DateTime ngay_sinh { get; set; }
        public string ghi_chu { get; set; }
        public int svlhp_nhom { get; set; }
        public string lhp_ma_lhp { get; set; }
        public string lhp_lop_hoc { get; set; }
        public string lhp_ten_mon_hoc { get; set; }
        public string lhp_nam_hk { get; set; }
        public string lh_tiet { get; set; }
        public DateTime lh_ngay_bat_dau { get; set; }
        public string lh_phong { get; set; }
        public string lh_giang_vien { get; set; }
        public string lh_ghi_chu { get; set; }
        public string th_tuan { get; set; }


    }
}
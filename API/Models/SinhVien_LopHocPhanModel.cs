using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class SinhVien_LopHocPhanModel
    {
        public string svlhp_id { get; set; }
        public string sv_ma_sv { get; set; }
        public string lhp_key_id { get; set; }
        public byte svlhp_nhom { get; set; }
    }
}
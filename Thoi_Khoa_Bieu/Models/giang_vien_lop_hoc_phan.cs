//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Thoi_Khoa_Bieu.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class giang_vien_lop_hoc_phan
    {
        public string gvlhp_id { get; set; }
        public string gv_id { get; set; }
        public string lhp_key_id { get; set; }
    
        public virtual giang_vien giang_vien { get; set; }
        public virtual lop_hoc_phan lop_hoc_phan { get; set; }
    }
}

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
    
    public partial class tuan_hoc
    {
        public string th_id { get; set; }
        public string th_tuan { get; set; }
        public string lh_id { get; set; }
    
        public virtual lich_hoc lich_hoc { get; set; }
    }
}

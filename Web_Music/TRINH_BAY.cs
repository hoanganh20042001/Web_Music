//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web_Music
{
    using System;
    using System.Collections.Generic;
    
    public partial class TRINH_BAY
    {
        public string MaNS { get; set; }
        public string MaSP { get; set; }
        public string GhiChu { get; set; }
    
        public virtual NGHE_SI NGHE_SI { get; set; }
        public virtual SAN_PHAM SAN_PHAM { get; set; }
    }
}
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
    
    public partial class ALbum
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ALbum()
        {
            this.SAN_PHAM = new HashSet<SAN_PHAM>();
        }
    
        public string TenAlbum { get; set; }
        public string MaKH { get; set; }
        public string GhiChu { get; set; }
        public string MaAl { get; set; }
    
        public virtual KHACH_HANG KHACH_HANG { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SAN_PHAM> SAN_PHAM { get; set; }
    }
}
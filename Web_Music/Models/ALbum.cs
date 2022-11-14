namespace Web_Music.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ALbum")]
    public partial class ALbum
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ALbum()
        {
            SAN_PHAM = new HashSet<SAN_PHAM>();
        }

        [Required]
        [StringLength(50)]
        public string TenAlbum { get; set; }

        [Required]
        [StringLength(10)]
        public string MaKH { get; set; }

        [StringLength(100)]
        public string GhiChu { get; set; }

        [Key]
        [StringLength(10)]
        public string MaAl { get; set; }

        public virtual KHACH_HANG KHACH_HANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SAN_PHAM> SAN_PHAM { get; set; }
    }
}

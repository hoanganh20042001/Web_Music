namespace Web_Music.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    public partial class KHACH_HANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACH_HANG()
        {
            ALbums = new HashSet<ALbum>();
            NGHEs = new HashSet<NGHE>();
            THEO_DOI = new HashSet<THEO_DOI>();
            TRUY_CAP_TM = new HashSet<TRUY_CAP_TM>();
            YEU_THICH = new HashSet<YEU_THICH>();
            URL_img = "~/Assets/img/KH/add.png";
        }

        [Required]
        [StringLength(50)]
        public string TenKH { get; set; }

        [StringLength(100)]
        public string URL_img { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Pass { get; set; }

        [StringLength(50)]
        public string DiaChi { get; set; }

        [Column(TypeName = "numeric")]
        public decimal SDT { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        public bool? TrangThai { get; set; }

        public bool? GT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CCCD { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(100)]
        public string GhiChu { get; set; }

        [Key]
        [StringLength(10)]
        public string MaKH { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ALbum> ALbums { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NGHE> NGHEs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THEO_DOI> THEO_DOI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRUY_CAP_TM> TRUY_CAP_TM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<YEU_THICH> YEU_THICH { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}

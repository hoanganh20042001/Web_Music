namespace Web_Music.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    public partial class NGHE_SI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NGHE_SI()
        {
            THEO_DOI = new HashSet<THEO_DOI>();
            TRINH_BAY = new HashSet<TRINH_BAY>();
            URL_img = "~/Assets/img/singer/add.png";
        }

        [Required]
        [StringLength(50)]
        public string TenNS { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(50)]
        public string QueQuan { get; set; }

        [StringLength(200)]
        public string NS_URL { get; set; }

        public bool? GT { get; set; }

        [StringLength(100)]
        public string GhiChu { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TheoDoi { get; set; }

        [StringLength(50)]
        public string NgheDanh { get; set; }

        [StringLength(100)]
        public string URL_img { get; set; }

        [Key]
        [StringLength(10)]
        public string mans { get; set; }

        [StringLength(10)]
        public string MaNhom { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THEO_DOI> THEO_DOI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRINH_BAY> TRINH_BAY { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}

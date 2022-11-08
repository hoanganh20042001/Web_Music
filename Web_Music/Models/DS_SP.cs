namespace Web_Music.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DS_SP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DS_SP()
        {
            ALbums = new HashSet<ALbum>();
        }

        [Key]
        [StringLength(10)]
        public string MaDS { get; set; }

        [StringLength(10)]
        public string MaSP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ALbum> ALbums { get; set; }

        public virtual SAN_PHAM SAN_PHAM { get; set; }
    }
}

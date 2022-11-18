namespace Web_Music.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DS_SP
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
<<<<<<< HEAD
        public string MaAL { get; set; }
=======
        public string MaAl { get; set; }
>>>>>>> 815059874ca72f3099d73534b6df15432f51588a

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaSP { get; set; }
<<<<<<< HEAD
=======
        public virtual ALbum ALbum{ get; set; }

        public virtual SAN_PHAM SAN_PHAM { get; set; }
>>>>>>> 815059874ca72f3099d73534b6df15432f51588a
    }
}

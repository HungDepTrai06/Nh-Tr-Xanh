namespace WebBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HUYENQUAN")]
    public partial class HUYENQUAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HUYENQUAN()
        {
            TINTUC = new HashSet<TINTUC>();
        }

        [Key]
        [StringLength(4)]
        [Display(Name = "Mã huyện")]
        public string MAHUYEN { get; set; }

        [Required]
        [StringLength(4)]
        [Display(Name = "Mã tỉnh")]
        public string MATINH { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Tên huyện")]
        public string TENHUYEN { get; set; }

        public virtual TINHTP TINHTP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TINTUC> TINTUC { get; set; }
    }
}

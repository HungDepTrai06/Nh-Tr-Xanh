namespace WebBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TINHTP")]
    public partial class TINHTP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TINHTP()
        {
            HUYENQUAN = new HashSet<HUYENQUAN>();
        }

        [Key]
        [StringLength(4)]
        [Display(Name ="Mã tỉnh")]
        public string MATINH { get; set; }

        [Required(ErrorMessage = "Mã tỉnh không thể rỗng")]
        [StringLength(50)]
        [Display(Name = "Tên tỉnh")]
        public string TENTINH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HUYENQUAN> HUYENQUAN { get; set; }
    }
}

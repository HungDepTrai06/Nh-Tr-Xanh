namespace WebBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOAITT")]
    public partial class LOAITT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAITT()
        {
            TINTUC = new HashSet<TINTUC>();
        }

        [Key]
        [Display(Name = "Mã thể loại tin tức")]
        public int MALOAITT { get; set; }

        [Required(ErrorMessage = "Tên loại tin tức không thể rỗng")]
        [StringLength(50)]
        [MaxLength(50,ErrorMessage ="Tên loại tin tức không vượt quá 50 ký tự")]
        [Display(Name = "Tên thể loại tin tức")]
        public string TENLOAITT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TINTUC> TINTUC { get; set; }
    }
}

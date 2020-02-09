namespace WebBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NGUOIDUNG")]
    public partial class NGUOIDUNG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NGUOIDUNG()
        {
            TINTUC = new HashSet<TINTUC>();
        }

        [Key]
        [Display(Name = "Mã người dùng")]
        public int MAND { get; set; }

        [StringLength(100, ErrorMessage ="Email không vượt quá 100 ký tự")]
        [Required(ErrorMessage = "Email không thể rỗng")]
        [EmailAddress(ErrorMessage = "Email không đúng, hãy nhập lại")]
        public string EMAIL { get; set; }

        [StringLength(500, MinimumLength =6, ErrorMessage ="Mật khẫu ít nhất phải có 6 ký tự")]
        [Required(ErrorMessage = "Mật khẫu không thể rỗng")]
        [Display(Name = "Mật khẫu")]
        public string MATKHAU { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Họ tên không thể rỗng")]
        [Display(Name = "Họ và tên")]
        public string HOTENND { get; set; }

        [Display(Name = "Giới tính")]
        public bool GIOITINH { get; set; }

        [Required(ErrorMessage = "Số điện thoại không thể rỗng")]
        [StringLength(10)]
        [Display(Name = "Số điện thoại 1")]
        [MinLength(10,ErrorMessage ="Số điện thoại phải đủ 10 số")]
        [MaxLength(10, ErrorMessage = "Số điện thoại phải đủ 10 số")]
        public string SDT1 { get; set; }

        [StringLength(10)]
        [MinLength(10, ErrorMessage = "Số điện thoại phải đủ 10 số")]
        [MaxLength(10, ErrorMessage = "Số điện thoại phải đủ 10 số")]
        public string SDT2 { get; set; }

        [Display(Name ="Cấp bậc")]
        [Range(1,2,ErrorMessage ="Cấp bặc chỉ có 1(Thành viên) và 2(quản trị)")]
        public int LEVEL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TINTUC> TINTUC { get; set; }
    }
}

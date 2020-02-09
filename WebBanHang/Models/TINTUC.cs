namespace WebBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TINTUC")]
    public partial class TINTUC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TINTUC()
        {
            DSANH = new HashSet<DSANH>();
        }

        [Key]
        [Display(Name = "Mã tin tức")]
        public int ID_TinTuc { get; set; }

        [Display(Name = "Mã người dùng")]
        public int MAND { get; set; }

        [Display(Name = "Mã loại tin tức")]
        public int MALOAITT { get; set; }

        [Required(ErrorMessage = "Mã huyện không thể rỗng")]
        [StringLength(4)]
        [Display(Name = "Mã huyện")]
        public string MAHUYEN { get; set; }

        [Required(ErrorMessage = "Tiêu đề không thể rỗng")]
        [StringLength(150, ErrorMessage = "Tiêu đề phải ít hơn 150 ký tự, bạn hãy kiểm tra lại")]
        [Display(Name = "Tiêu đề")]
        public string TIEUDE { get; set; }

        [Required(ErrorMessage = "Nội dung không thể rỗng")]
        [StringLength(600, ErrorMessage = "Nội dung phải ít hơn 600 ký tự, bạn hãy kiểm tra lại")]
        [Display(Name = "Nội dung")]
        public string NOIDUNG { get; set; }


        [Display(Name = "Giá tiền")]
        [Required(ErrorMessage = "Giá tiền không thể rỗng")]
        
        //[RegularExpression("\\d", ErrorMessage ="Giá tiền bạn nhập không hợp lệ")]
        [Range(500000,15000000,ErrorMessage ="Giá tiền thấp nhất là 500.000 VNĐ và cao nhất là 15.000.000 VNĐ")]
        public double GIATIEN { get; set; }

        [Required(ErrorMessage = "Địa chỉ không thể rỗng")]
        [StringLength(200, ErrorMessage ="Địa chỉ phải ít hơn 200 ký tự, bạn hãy kiểm tra lại")]
        [Display(Name = "Địa chỉ")]
        public string DIACHITT { get; set; }

        [StringLength(200,ErrorMessage ="Tiện ích không vượt quá 200 ký tự")]
        [Display(Name = "Tiện ích")]
        public string TIENICH { get; set; }

        [Display(Name = "Trạng thái")]
        public bool TRANGTHAI { get; set; }

        //[Column(TypeName = "date")]
        [Display(Name = "Ngày đăng tin")]
        public DateTime NGAYDT { get; set; }

        //[Column(TypeName = "date")]
        [Display(Name = "Ngày hết hạn")]
        public DateTime NGAYKT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DSANH> DSANH { get; set; }

        public virtual HUYENQUAN HUYENQUAN { get; set; }

        public virtual LOAITT LOAITT { get; set; }

        public virtual NGUOIDUNG NGUOIDUNG { get; set; }
    }
}

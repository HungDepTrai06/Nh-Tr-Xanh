using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanHang.Models
{
    public class PhanHoi
    {
        [StringLength(100, ErrorMessage = "Email không vượt quá 100 ký tự")]
        [Required(ErrorMessage = "Email không thể rỗng")]
        [EmailAddress(ErrorMessage = "Email không đúng, hãy nhập lại")]
        public string EMAIL { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Họ tên không thể rỗng")]
        [Display(Name = "Họ và tên")]
        public string HOTEN { get; set; }

        [Required(ErrorMessage = "Số điện thoại không thể rỗng")]
        [StringLength(10)]
        [Display(Name = "Số điện thoại 1")]
        [MinLength(10, ErrorMessage = "Số điện thoại phải đủ 10 số")]
        [MaxLength(10, ErrorMessage = "Số điện thoại phải đủ 10 số")]
        public string SDT1 { get; set; }

        [Required(ErrorMessage = "Nội dung không thể rỗng")]
        [StringLength(400, ErrorMessage = "Nội dung phải ít hơn 400 ký tự, bạn hãy kiểm tra lại")]
        [Display(Name = "Nội dung")]
        public string NOIDUNG { get; set; }
    }
}
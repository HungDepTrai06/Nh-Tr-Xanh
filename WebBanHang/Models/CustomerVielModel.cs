using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace WebBanHang.Models
{
    public class CustomerVielModel
    {

        [Required(ErrorMessage = "Họ và tên không thể rỗng")]
        [Display(Name = "Họ và tên")]
        public string HoTen { set; get; }

        [StringLength(100, ErrorMessage = "Email không vượt quá 100 ký tự")]
        [Required(ErrorMessage = "Email không thể rỗng")]
        [EmailAddress(ErrorMessage = "Email không đúng ")]
        public string Email { set; get; }

        [StringLength(500, MinimumLength = 6, ErrorMessage = "Mật khẫu ít nhất phải có 6 ký tự ")]
        [Required(ErrorMessage = "Mật khẫu không thể rỗng ")]
        [Display(Name = "Mật khẫu")]
        public string PW_ND { set; get; }

        [Display(Name = "Nhập lại mật khẫu")]
        [Required(ErrorMessage = "Có vẻ bạn chưa nhập lại mật khẫu ")]
        [Compare("PW_ND",ErrorMessage ="Mật khẫu nhập lại chưa đúng ")]
        public string PasswordConfirm { set; get; }


        [Display(Name = "Giới tính")]
        public bool GIOITINH { get; set; }

        [Required(ErrorMessage = "Số điện thoại không thể rỗng ")]
        [Display(Name = "Số điện thoại 1")]
        [MinLength(10, ErrorMessage = "Số điện thoại phải đủ 10 số")]
        [MaxLength(10, ErrorMessage = "Số điện thoại phải đủ 10 số")]
        public string SDT1 { set; get; }

        [Display(Name = "Số điện thoại 2")]
        [MinLength(10, ErrorMessage = "Số điện thoại phải đủ 10 số")]
        [MaxLength(10, ErrorMessage = "Số điện thoại phải đủ 10 số")]
        public string SDT2 { set; get; }
    }
}
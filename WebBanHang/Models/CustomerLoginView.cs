using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace WebBanHang.Models
{
    public class CustomerLoginView
    {
        [StringLength(100, ErrorMessage = "Email không vượt quá 100 ký tự")]
        [Required(ErrorMessage = "Email không thể rỗng")]
        [EmailAddress(ErrorMessage = "Email không đúng")]
        public string Email { set; get; }

        [Required(ErrorMessage = "Mật khẫu không thể rỗng")]
        [Display(Name = "Mật khẫu")]
        public string MATKHAU { set; get; }
    }
}
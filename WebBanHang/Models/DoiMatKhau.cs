using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanHang.Models
{
    public class DoiMatKhau
    {
        public string MKC { get; set; }

        [Required(ErrorMessage = "Mật khẫu không thể rỗng, bạn hãy xem lại")]
        [Display(Name = "Mật khẫu")]
        public string MatKhauMoi { set; get; }

        [Display(Name = "Nhập lại mật khẫu")]
        [Required(ErrorMessage = "Có vẻ bạn chưa nhập lại mật khẫu, bạn hãy xem lại")]
        [Compare("MatKhauMoi", ErrorMessage = "Mật khẫu nhập lại chưa đúng, bạn hãy xem lại")]
        public string PasswordConfirm { set; get; }
    }
}
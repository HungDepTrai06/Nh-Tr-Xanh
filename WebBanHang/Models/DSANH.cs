namespace WebBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DSANH")]
    public partial class DSANH
    {
        [Key]
        [Display(Name = "Mã hình ảnh")]
        public int ID_ANH { get; set; }

        public int ID_TINTUC { get; set; }

        [Required(ErrorMessage ="Đường dẫn không thể rỗng")]
        [StringLength(100)]
        [MaxLength(100,ErrorMessage ="Tên file không vượt quá 100 ký tự")]
        [Display(Name = "Đường dẫn")]
        public string DUONGDAN { get; set; }

        public virtual TINTUC TINTUC { get; set; }
    }
}

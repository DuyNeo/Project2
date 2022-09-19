using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QLHS.Models
{
    public class NguoiDung
    {
        [Key]
        public int idNguoiDung { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Tài khoản")]
        [Required(ErrorMessage = "Bạn cần nhập tài khoản")]
        [StringLength(50)]
        public string tenNguoiDung { get; set; }
        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Bạn cần nhập họ tên")]
        [Column(TypeName = "nvarchar(100)")]
        [StringLength(50)]
        public string tenDaydu { get; set; }
        [Required]
        [StringLength(50)]
        [RegularExpression("^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$", ErrorMessage = "Email is not valid")]
        public string Email { get; set; }
        [Display(Name = "Chức danh")]
        [Column(TypeName = "nvarchar(100)")]

        public string chucDanh { get; set; }
        [Display(Name = "Giới Tính")]
        public Gender gioiTinh { get; set; }
        [Display(Name = "Ngày sinh")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DOB { get; set; }
        [Display(Name = "Quản trị")]
        public bool IsAdmin { get; set; }
        [Display(Name ="Đang sử dụng")]
        public bool Locked { get; set; }
        [Column(TypeName = "varchar(50)"), MaxLength(50)]
        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        public string matKhau { get; set; }
        [Column(TypeName = "varchar(50)"), MaxLength(50)]
        [Display(Name = "Nhập lại mật khẩu")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Mật khẩu không khớp")]
        [NotMapped]
        public string xacNhanMatKhau { get; set; }


    }
    public enum Gender
    {
        [Display(Name = "Nam")]
        Nam = 1,
        [Display(Name = "Nữ")]
        Nữ = 2,
    }

}

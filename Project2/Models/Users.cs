using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models
{
    public enum GT
    {
        [Display(Name = "Nam")]
        Nam = 1,
        [Display(Name = "Nữ")]
        Nữ = 2,
    }
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Tài khoản")]
        [Required(ErrorMessage = "Bạn cần nhập tài khoản")]
        [StringLength(50)]
        public string UserName { get; set; }
        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Bạn cần nhập họ tên")]
        [Column(TypeName = "nvarchar(100)")]
        [StringLength(50)]
        public string UserFullName { get; set; }
        [Required]
        [StringLength(50)]
        [RegularExpression("^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$", ErrorMessage = "Email is not valid")]
        public string Email { get; set; }
        [Display(Name = "Chức danh")]
        [Column(TypeName = "nvarchar(100)")]

        public string Title { get; set; }
        [Display(Name = "Giới Tính")]
        public GT Gender { get; set; }
        [Display(Name = "Ngày sinh")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DOB { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
        [Display(Name = "Đang sử dụng")]
        public bool Locked { get; set; }

        [Column(TypeName = "varchar(50)"), MaxLength(50)]
        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Column(TypeName = "varchar(50)"), MaxLength(50)]
        [Display(Name = "Nhập lại mật khẩu")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Mật khẩu không khớp")]
        [NotMapped]
        public string ConfirmPassword { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public List<Score> scores { get; set; }

        public List<Schedule> schedules { get; set; }


    }
}

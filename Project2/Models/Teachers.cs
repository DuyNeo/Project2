using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models
{
    public class Teachers
    {
        [Key]
        public int TeachersId { get; set; }
        [Display(Name = "Họ")]
        public string LastName { get; set; }
        [Display(Name = "Tên")]
        public string FisrtName { get; set; }
        [Display(Name = "Mã giáo viên")]
        public int TeachersCode { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Mã số thuế")]
        public int TaxCode { get; set; }
        [Display(Name = "Số điện thoại")]
        [Column(TypeName = "varchar(10)"), MinLength(10), MaxLength(10)]
        [DataType(DataType.PhoneNumber)]
        public string NumberPhone { get; set; }
        [Display(Name = "Địa chỉ")]
        [StringLength(100)]
        public string Address { get; set; }
        [Display(Name = "Giới tính")]
        public Gender Gender { get; set; }
        [Display(Name = "Ngày sinh")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DOB { get; set; }
        [Display(Name = "Hình Ảnh Đại Diện")]
        [Column(TypeName = "varchar(200)"), MaxLength(100)]
        public string Image { get; set; }

        [Display(Name = "Lớp Học")]
        [StringLength(20)]
        public string lop { get; set; }

        [Display(Name = "Môn Dạy Chính")]
        [StringLength(200)]
        public string CoreSubject { get; set; }

        [Display(Name = "Môn Kiêm Nhiệm")]
        [StringLength(200)]
        public string Concurrently { get; set; }
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

        //[ForeignKey("Role")]
      
        //public  Class Class { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public List<Schedule> schedules { get; set; }

    }
    public enum Gender
    {
        [Display(Name = "Nam")]
        Nam = 1,
        [Display(Name = "Nữ")]
        Nữ = 2,
    }
}

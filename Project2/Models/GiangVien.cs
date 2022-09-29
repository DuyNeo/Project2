using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models
{
    public class GiangVien
    {
        [Key]
        public int gvId { get; set; }
        [Display(Name = "Họ")]
        public string Ho { get; set; }
        [Display(Name = "Tên")]
        public string Ten { get; set; }
        [Display(Name = "Mã giáo viên")]
        public int maGV { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Mã số thuế")]
        public int maSoThue { get; set; }
        [Display(Name = "Số điện thoại")]
        [Column(TypeName = "varchar(10)"), MinLength(10), MaxLength(10)]
        [DataType(DataType.PhoneNumber)]
        public string soDienThoai { get; set; }
        [Display(Name = "Địa chỉ")]
        [StringLength(100)]
        public string diaChi { get; set; }
        [Display(Name = "Giới tính")]
        public Gender gioiTinh { get; set; }
        [Display(Name = "Ngày sinh")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DOB { get; set; }
        [Display(Name = "Hình Ảnh Đại Diện")]
        [Column(TypeName = "varchar(200)"), MaxLength(100)]
        public string Hinh { get; set; }

        [Display(Name = "Lớp Học")]
        [StringLength(20)]
        public string Lop { get; set; }

        [Display(Name = "Môn Dạy Chính")]
        [StringLength(200)]
        public string monHocChinh { get; set; }

        [Display(Name = "Môn Kiêm Nhiệm")]
        [StringLength(200)]
        public string monKienNhiem { get; set; }
        [Column(TypeName = "varchar(50)"), MaxLength(50)]
        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        public string matKhau { get; set; }
        [Column(TypeName = "varchar(50)"), MaxLength(50)]
        [Display(Name = "Nhập lại mật khẩu")]
        [DataType(DataType.Password)]
        [Compare("matKhau", ErrorMessage = "Mật khẩu không khớp")]
        [NotMapped]
        public string xacNhanMatKhau { get; set; }
        [ForeignKey("Role")]
        public int Role { get; set; }
        public Role role { get; set; }
        public virtual LopHoc lopHoc {get;set;}


    }
    public enum Gender
    {
        [Display(Name = "Nam")]
        Nam = 1,
        [Display(Name = "Nữ")]
        Nữ = 2,
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models
{
    public class LopHoc
    {
        [Key]
        public int lopHocId { get; set; }
        [Display(Name ="Mã lớp")]
        public int lopHocMa { get; set; }
        [StringLength(20)]
        [Display(Name = "Tên Lớp")]
        public string lopHocTen { get; set; }

        [StringLength(20)]
        [Display(Name = "Niên Khóa")]
        public string nienKhoa { get; set; }

        [StringLength(50)]
        [Display(Name = "Mô Tả")]
        public string moTa { get; set; }

        [Display(Name = "Tên Khóa")]
        [StringLength(30)]
        public string tenKhoa { get; set; }

        [Display(Name = "Số Lượng")]
        public int soLuong { get; set; }

        [Display(Name = "Trạng Thái")]
        public bool trangThai { get; set; }

        [Display(Name = "Học Phí")]
        public double hocPhi { get; set; }

        [ForeignKey("nguoiDung")]
        public int Lop { get; set; }
        public virtual NguoiDung nguoiDung { get; set; }

        public KhoaHoc khoaHoc { get; set; }

    }
}

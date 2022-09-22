using Grpc.Core;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models
{
    public class HocPhi
    {
        [Key]
        public int hocPhiId { get; set; }

        [ForeignKey("nguoiDung")]
        public int hocPhiNguoiDungId { get; set; }

        [Display(Name = "Lớp Học")]
       
        public string lopHoc { get; set; }

        [Display(Name = "Khóa Đào Tạo")]
        
        public string khoaDaoTao { get; set; }

        [Display(Name = "Thu Phí")]
        public double thuPhi { get; set; }

        [Display(Name = "Loại Học Phí")]
       
        public string loaiThuPhi { get; set; }

        [Display(Name = "Mức Thu Phí")]
        public double mucThuPhi { get; set; }

        [Display(Name = "Giảm Giá")]
        public int giamGia { get; set; }

        [Display(Name = "Ghi Chú")]
        [StringLength(50)]
        public string ghiChu { get; set; }

        [Display(Name = "Trạng Thái")]
        public string trangThai { get; set; }

        public NguoiDung nguoiDung { get; set; }
    }
}

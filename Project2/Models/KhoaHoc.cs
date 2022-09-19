using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models
{
    public class KhoaHoc
    {
        [Key]
        public int khoaHocId { get; set; }

        [Display(Name = "Mã Khóa")]
        
        public string khoaHocMa { get; set; }

        [Display(Name = "Tên Khóa")]
        
        public string khoaHocTen { get; set; }

        [Display(Name = "Ngày Bắt Đầu")]
        public DateTime ngayBatDau { get; set; }

        [Display(Name = "Ngày Kết Thúc")]
        public DateTime ngayKetThuc { get; set; }
    }
}

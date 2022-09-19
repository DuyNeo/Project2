using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models
{
    public class LoaiDiem
    {
        [Key]
        public int loaiDiemId { get; set; }

        [Display(Name = "Tên Loại Điểm"),
        StringLength(20)]
        public string loaiDiemTen { get; set; }

        [Display(Name = "Hệ Số")]
        public int HeSo { get; set; }
        
    }
}

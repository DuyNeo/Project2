using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models
{
    public class Diem
    {
        [Key]
        public int diemId { get; set; }

        [ForeignKey("monHoc")]
        public int diemMonHoc { get; set; }

        //[ForeignKey("loaiDiem")]
        //public int loaiDiemId { get; set; }

        [Display(Name = "Tên Khóa Đào Tạo")]
        [StringLength(20)]
        public string tenKhoa { get; set; }

        [Display(Name = "Tên Môn Học")]
        [StringLength(20)]
        public string tenMonHoc { get; set; }

        [Display(Name = "Số Cột Điểm")]
        public int soCotDiem { get; set; }

        [Display(Name = "Số Cột Điểm Bắt Buộc")]
        public int soCotDiemBatBuoc { get; set; }

        public LoaiDiem loaiDiem { get; set; }

        public MonHoc monHoc { get; set; }

    }
}

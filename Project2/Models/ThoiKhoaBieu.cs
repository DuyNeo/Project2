
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models
{
    public class ThoiKhoaBieu
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("nguoiDung")]
        public int ScheduleUser { get; set; }

        [ForeignKey("subjectModel")]
        public int ScheduleSubject { get; set; }

        //[ForeignKey("classModel")]
        //public int ScheduleClassId { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên Giáo Viên")]
        public string tenGiaoVien { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên Lớp")]
        public string tenLop { get; set; }

        [StringLength(50)]
        [Display(Name = "Môn Học")]
        public string monHoc { get; set; }

        [StringLength(50)]
        [Display(Name = "Phòng Học")]
        public string phongHoc { get; set; }

        [Display(Name = "Giờ Học")]
        public DateTime gioHoc { get; set; }

        [Display(Name = "Thứ")]
        public DateTime Thu { get; set; }

        [Display(Name = "Ngày Bắt Đầu")]
        public DateTime ngauBatDau { get; set; }

        [Display(Name = "Ngày Kết Thúc")]
        public DateTime ngayKetThuc { get; set; }

        [Display(Name = "Thời Gian")]
        public DateTime thoiGian { get; set; }


        public NguoiDung nguoiDung { get; set; }
        public MonHoc MonHoc { get; set; }
    }
}

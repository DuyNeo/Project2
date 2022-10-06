using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models
{
    public class Course //KhoaHoc
    {
        [Key]
        public int CourseId { get; set; }

        [Display(Name = "Mã Khóa")]
        
        public string CourseCode { get; set; }

        [Display(Name = "Tên Khóa")]
        
        public string CourseName { get; set; }

        [Display(Name = "Ngày Bắt Đầu")]
        public DateTime StartDay { get; set; }

        [Display(Name = "Ngày Kết Thúc")]
        public DateTime EndDay { get; set; }
        public List<Subjects> subjects { get; set; }
        
    }
}

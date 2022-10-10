
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models
{
    public class Schedule//Thoi Khoa Bieu
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên Giáo Viên")]
        public string TeacherName { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên Lớp")]
        public string ClassName { get; set; }
        [StringLength(50)]
        [Display(Name = "Phòng Học")]
        public string ClassRoom { get; set; }

        [Display(Name = "Giờ Học")]
        public string Hours { get; set; }

        public bool Mon { get; set; }
        public bool Tue { get; set; }
        public bool Wed { get; set; }
        public bool Thu { get; set; }
        public bool Fri { get; set; }
        public bool Sat { get; set; }
        public bool Sun { get; set; }
        [Required]
        [Display(Name = "Giờ Bắt Đầu")]
        public DateTime StartTime { get; set; }

        [Display(Name = "Giờ Kết Thúc")]
        public DateTime Time { get; set; }

        //[Display(Name = "Thời Gian")]
        //public DateTime Time { get; set; }

        public int UserId { get; set; }
        public Users users { get; set; }
        //public int TeachersId { get; set; }
        //public Teachers teachers { get; set; }
        public int SubjectId { get; set; }
        public Subjects subjects { get; set; }
    }
}

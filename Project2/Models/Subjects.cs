using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models
{
    public class Subjects//Mon Hoc
    {
        [Key]
        public int SubjectId { get; set; }

        [Display(Name = "Mã Môn Học"), StringLength(30)]
        public string SubjectCode { get; set; }

        [Display(Name = "Tên Môn Học"), StringLength(30)]
        public string SubjectName { get; set; }

        public int DepartmentId { get; set; }
       
        public Department department { get; set; }

        public int CourseId { get; set; }
        public Course course { get; set; }
        public List<Score> scores { get; set; }
        public List<Schedule> schedules { get; set; }
        
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }
        [Display(Name = "Mã lớp")]
        public int ClassCode { get; set; }
        [StringLength(20)]
        [Display(Name = "Tên Lớp")]
        public string ClassName { get; set; }

        [StringLength(20)]
        [Display(Name = "Niên Khóa")]
        public string Year { get; set; }

        [StringLength(50)]
        [Display(Name = "Mô Tả")]
        public string Describe { get; set; }

        [Display(Name = "Tên Khóa")]
        [StringLength(30)]
        public string CouresName { get; set; }

        [Display(Name = "Số Lượng")]
        public int Amount { get; set; }

        [Display(Name = "Trạng Thái")]
        public bool Status { get; set; }

        [Display(Name = "Học Phí")]
        public double TuitionFee { get; set; }

        //[ForeignKey("Users")]

        //public int ClassUser { get; set; }

        //public int UserId { get; set; }
        
        //public virtual Users users { get; set; }

        public List<Users> users { get; set; }
        //public virtual Class Classes { get; set; }
        [ForeignKey("Course")]
        //public Course course { get; set; }
        public int CourseId { get; set; }


    }
}

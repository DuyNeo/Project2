using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models
{
    public class Score//Diem

    {
        [Key]
        public int ScoreId { get; set; }

        //public int subjectScore { get; set; }
        //[Display(Name = "Tên Khóa Đào Tạo")]
        //[StringLength(20)]
        //public string sourseName { get; set; }
        [Display(Name = "Điểm")]
        public float Diem { get; set; }

        //[Display(Name = "Số Cột Điểm Bắt Buộc")]
        //public int soCotDiemBatBuoc { get; set; }
        //kieu diem
        public int UserId { get; set; }
        public Users users { get; set; }
        public int PointTypeId { get; set; }
        public PointType pointTypes { get; set; }
        //ma mon
        public int SubjectsId {get;set;}
        public Subjects subjects { get; set; }

    }
}

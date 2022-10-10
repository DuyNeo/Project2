using Grpc.Core;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models
{
    public class Tuition
    {
        [Key]
        public int TuitionId { get; set; }
        [Display(Name = "Lớp Học")]
  
        public string Class { get; set; }

        [Display(Name = "Khóa Đào Tạo")]
        
        public string Training { get; set; }

        [Display(Name = "Thu Phí")]
        public double Fee { get; set; }

        [Display(Name = "Loại Học Phí")]
       
        public string TollType { get; set; }

        [Display(Name = "Mức Thu Phí")]
        public double FeeRate { get; set; }

        [Display(Name = "Giảm Giá")]
        public int Discount { get; set; }

        [Display(Name = "Ghi Chú")]
        [StringLength(50)]
        public string Note { get; set; }

        [Display(Name = "Trạng Thái")]
        public string Status { get; set; }
        

        public int UserId { get; set; }
        public Users users { get; set; }
    }
}

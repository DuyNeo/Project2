using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models
{
    public class PointType
    {
        [Key]
        public int PointTypeId { get; set; }

        [Display(Name = "Tên Loại Điểm"),
        StringLength(20)]
        public string PointTypeName { get; set; }

        [Display(Name = "Hệ Số")]
        public int Coefficient { get; set; }
        public List<Score> scores { get; set; }
    }
}

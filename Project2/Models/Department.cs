using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models
{
    public class Department //To Bo Mon
    {
        [Key]
        public int DepartmentId { get; set; }
        [Display(Name = "Tên Tổ Bộ Môn")]
        public string DepartmentName { get; set; }
        public List<Subjects> subjects { get; set; }
    }
}

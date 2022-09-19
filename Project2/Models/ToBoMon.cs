using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models
{
    public class ToBoMon
    {
        [Key]
        public int toBoMonId { get; set; }
        [Display(Name = "Tên Tổ Bộ Môn")]
        public string toBoMonTen { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models
{
    public class Salary
    {
        [Key]
        public int SalaryId { get; set; }
        public int SalaryMoth { get; set; }
        public bool Status { get; set; }
        public int TeacherId { get; set;}
        public Teachers teachers { get; set; }
    }
}

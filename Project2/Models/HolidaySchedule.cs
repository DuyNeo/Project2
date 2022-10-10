using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models
{
    public class HolidaySchedule
    {
        [Key]
        public int HolidayId { get; set; }
        [Required, Column(TypeName = "nvarchar(255)")]
        public string HolidayName { get; set; }
        [Required, Column(TypeName = "nvarchar(255)")]
        public string Reason { get; set; }//lí do
        public DateTime StartDay { get; set; }//ngày bắt đầu
        public DateTime EndDay { get; set; }//ngày kết thúc
    }
}

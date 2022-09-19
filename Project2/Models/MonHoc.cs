using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models
{
    public class MonHoc
    {
        [Key]
        public int monHocId { get; set; }

        [ForeignKey("ToBoMon")]
        public int boMonHoc { get; set; }

        [ForeignKey("KhoaHoc")]
        public int monHoc { get; set; }

        [Display(Name = "Mã Môn Học"), StringLength(30)]
        public string monHocMa { get; set; }

        [Display(Name = "Tên Môn Học"), StringLength(30)]
        public string monHocTen { get; set; }

        public ToBoMon toBoMon { get; set; }
        public KhoaHoc khoaHoc { get; set; }
    }
}

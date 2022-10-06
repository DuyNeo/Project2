﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        [Column(TypeName = "varchar(50)"), MaxLength(50)]
       
        public string RoleName { get; set; }
        
        public List<Users> users { get; set; }
        public List<Teachers> teachers { get; set; }
    }
}

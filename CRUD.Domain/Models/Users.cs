﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Domain.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string CompanyName {  get; set; }
        public string Email { get; set; }
        public bool IsDelete { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsAdmin { get; set; }
        public string ?CreatedBy { get; set; }  
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string ?UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Country { get; set; }
        public string County { get; set; }

       
    }
}

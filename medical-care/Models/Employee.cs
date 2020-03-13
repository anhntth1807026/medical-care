using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace medical_care.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public string DeletedAt { get; set; }
        public int UpdatedBy { get; set; }
        public EmpStatus EmpStatus { get; set; }
        public Employee()
        {
            CreatedAt = DateTime.Now;
        }
    }
    public enum EmpStatus
    {
        NEW = 1, NORMAL = 0, PENDING = 2, FROZEN = -1
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace medical_care.Models
{
    public class PolicyOnEmp
    {
        [Key]
        public int Id { get; set; }
        public string PolicyName { get; set; }
        public decimal PolicyAmount { get; set; }
        public int PolicyDuration { get; set; }
        public decimal Emi { get; set; }
        public DateTime PolicyStart { get; set; }
        public DateTime PolicyEnd { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public string DeletedAt { get; set; }
        public PolOnEmpStatus Status { get; set; }
        public string EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }
        public int PolicyId { get; set; }
        [ForeignKey("PolicyId")]
        public virtual Policy Policy { get; set; }
        public PolicyOnEmp()
        {
            CreatedAt = DateTime.Now;
        }
    }

    public enum PolOnEmpStatus
    {
        ACTIVE = 1, DEACTIVE = 0, PENDING = 2, CONFIRM = 3
    }
}
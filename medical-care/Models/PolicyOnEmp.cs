using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace medical_care.Models
{
    public class PolicyOnEmp
    {
        public string PolicyName { get; set; }
        public string PolicyAmount { get; set; }
        public int PolicyDuration { get; set; }
        public string Emi { get; set; }
        public DateTime PolicyStart { get; set; }
        public DateTime PolicyEnd { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public PolOnEmpStatus Status { get; set; }
        public int EmployeeId { get; set; }
        public int PolicyId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Policy Policy { get; set; }
    }

    public enum PolOnEmpStatus
    {
        ACTIVE = 1, DEACTIVE = 0
    }
}
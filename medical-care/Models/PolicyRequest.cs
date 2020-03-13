using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace medical_care.Models
{
    public class PolicyRequest
    {
        [Key]
        public int RequestId { get; set; }
        public DateTime RequestDate { get; set; }
        public decimal Emi { get; set; }
        public PolicyRequestStatus Status { get; set; }
        public int EmployeeId { get; set; }
        public int PolicyId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Policy Policy { get; set; }
    }

    public enum PolicyRequestStatus
    {
        ACTIVE = 1, DEACTIVE = 0
    }
}
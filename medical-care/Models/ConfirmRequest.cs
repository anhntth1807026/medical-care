using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace medical_care.Models
{
    public class ConfirmRequest
    {
        [Key]
        public int Id { get; set; }
        public DateTime ConfirmRequestDate { get; set; }
        public decimal Amount { get; set; }
        public decimal Emi { get; set; }
        public string CompanyName { get; set; }
        public string PolicyName { get; set; }
        public ConfirmRequestStatus Status { get; set; }
        public string EmployeeId { get; set; }
        public int PolicyId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Policy Policy { get; set; }
        public virtual Company Company { get; set; }
    }

    public enum ConfirmRequestStatus
    {
        DEACTIVE = 0, ACTIVE = 1, PENDING = 2, CONFIRM = 3
    }
}
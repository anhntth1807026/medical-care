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
        public decimal Amount { get; set; }
        public decimal Emi { get; set; }
        public string CompanyName { get; set; }
        public string PolicyName { get; set; }
        public PolicyRequestStatus Status { get; set; }
        public string Id { get; set; }
        public int PolicyId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Policy Policy { get; set; }
        public virtual Company Company { get; set; }
    }

    public enum PolicyRequestStatus
    {
        DEACTIVE = 0, ACTIVE = 1
    }
}
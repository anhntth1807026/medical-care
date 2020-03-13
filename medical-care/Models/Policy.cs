using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace medical_care.Models
{
    public class Policy
    {
        [Key] public int PolicyId { get; set; }
        public int CompanyId { get; set; }
        public int HospitalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public decimal Emi { get; set; }
        public decimal AmountOfYear { get; set; }
        public string Duration { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public PolicyStatus Status { get; set; }
        public virtual Company Company { get; set; }
        public virtual Hospital Hospital { get; set; }
        public virtual PolicyRequest PolicyRequest { get; set; }
    }
    public enum PolicyStatus
    {
        NEW = 1, NORMAL = 0, PENDING = 2, FROZEN = -1
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace medical_care.Models
{
   
    public class Company
    {
        [Key] public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Url { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public string DeletedAt { get; set; }
        public CompanyStatus Status { get; set; }
        public Company()
        {
            CreatedAt = DateTime.Now;
        }
    }
    public enum CompanyStatus
    {
        ACTIVE = 1, DEACTIVE = 0
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace medical_care.Models
{
    public class Hospital
    {
        public int HospitalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Url { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public string DeletedAt { get; set; }
        public HospitalStatus Status { get; set; }
        public ICollection<Policy> Policies { get; set; }
        public Hospital()
        {
            CreatedAt = DateTime.Now;
        }
    }

    public enum HospitalStatus
    {
        ACTIVE = 1, DEACTIVE = 0
    }

    //public enum HospitalStatus
    //{
    //    ACTIVE = 1, DEACTIVE = 0
    //}
}
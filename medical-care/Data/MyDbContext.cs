using System;
using System.Data.Entity;
using System.Linq;
using medical_care.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace medical_care.Data
{
    
    public class MyDbContext : IdentityDbContext
    {
        // Your context has been configured to use a 'MyDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'medical_care.Data.MyDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MyDbContext' 
        // connection string in the application configuration file.
        public MyDbContext()
            : base("name=MyDbContext")
        {
        }

        public static MyDbContext Create()
        {
            return new MyDbContext();
        }
        //public System.Data.Entity.DbSet<medical_care.Models.AppRole> IdentityRoles { get; set; }

        public System.Data.Entity.DbSet<medical_care.Models.Company> Companies { get; set; }

        public System.Data.Entity.DbSet<medical_care.Models.Employee> Employees { get; set; }

        public System.Data.Entity.DbSet<medical_care.Models.Hospital> Hospitals { get; set; }

        public System.Data.Entity.DbSet<medical_care.Models.Policy> Policies { get; set; }

        public System.Data.Entity.DbSet<medical_care.Models.PolicyRequest> PolicyRequests { get; set; }
        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}
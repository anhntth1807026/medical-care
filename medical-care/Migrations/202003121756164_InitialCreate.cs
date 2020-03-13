namespace medical_care.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Thumbnail = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Url = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        EmpStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Hospitals",
                c => new
                    {
                        HospitalId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Thumbnail = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Url = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HospitalId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Hospitals");
            DropTable("dbo.Employees");
            DropTable("dbo.Companies");
        }
    }
}

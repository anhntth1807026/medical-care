namespace medical_care.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initializeDB : DbMigration
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
                        UpdatedAt = c.String(),
                        DeletedAt = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.Policies",
                c => new
                    {
                        PolicyId = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        HospitalId = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Emi = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AmountOfYear = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Duration = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.String(),
                        DeletedAt = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PolicyId)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.Hospitals", t => t.HospitalId, cascadeDelete: true)
                .Index(t => t.CompanyId)
                .Index(t => t.HospitalId);
            
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
                        UpdatedAt = c.String(),
                        DeletedAt = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HospitalId);
            
            CreateTable(
                "dbo.ContactUs",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        Phone = c.String(),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.Username);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        Password = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.String(),
                        DeletedAt = c.String(),
                        EmpStatus = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.PolicyOnEmps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PolicyName = c.String(),
                        CompanyName = c.String(),
                        HospitalName = c.String(),
                        PolicyAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PolicyDuration = c.Int(nullable: false),
                        Emi = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RequestDate = c.DateTime(nullable: false),
                        PolicyStart = c.DateTime(nullable: false),
                        PolicyEnd = c.DateTime(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.String(),
                        DeletedAt = c.String(),
                        Status = c.Int(nullable: false),
                        EmployeeId = c.String(maxLength: 128),
                        PolicyId = c.Int(nullable: false),
                        Company_CompanyId = c.Int(),
                        Hospital_HospitalId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.Company_CompanyId)
                .ForeignKey("dbo.AspNetUsers", t => t.EmployeeId)
                .ForeignKey("dbo.Hospitals", t => t.Hospital_HospitalId)
                .ForeignKey("dbo.Policies", t => t.PolicyId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.PolicyId)
                .Index(t => t.Company_CompanyId)
                .Index(t => t.Hospital_HospitalId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PolicyOnEmps", "PolicyId", "dbo.Policies");
            DropForeignKey("dbo.PolicyOnEmps", "Hospital_HospitalId", "dbo.Hospitals");
            DropForeignKey("dbo.PolicyOnEmps", "EmployeeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PolicyOnEmps", "Company_CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Policies", "HospitalId", "dbo.Hospitals");
            DropForeignKey("dbo.Policies", "CompanyId", "dbo.Companies");
            DropIndex("dbo.PolicyOnEmps", new[] { "Hospital_HospitalId" });
            DropIndex("dbo.PolicyOnEmps", new[] { "Company_CompanyId" });
            DropIndex("dbo.PolicyOnEmps", new[] { "PolicyId" });
            DropIndex("dbo.PolicyOnEmps", new[] { "EmployeeId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Policies", new[] { "HospitalId" });
            DropIndex("dbo.Policies", new[] { "CompanyId" });
            DropTable("dbo.PolicyOnEmps");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.ContactUs");
            DropTable("dbo.Hospitals");
            DropTable("dbo.Policies");
            DropTable("dbo.Companies");
        }
    }
}

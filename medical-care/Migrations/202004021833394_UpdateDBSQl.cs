namespace medical_care.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDBSQl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConfirmRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConfirmRequestDate = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Emi = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CompanyName = c.String(),
                        PolicyName = c.String(),
                        Status = c.Int(nullable: false),
                        EmployeeId = c.String(maxLength: 128),
                        PolicyId = c.Int(nullable: false),
                        Company_CompanyId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.Company_CompanyId)
                .ForeignKey("dbo.AspNetUsers", t => t.EmployeeId)
                .ForeignKey("dbo.Policies", t => t.PolicyId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.PolicyId)
                .Index(t => t.Company_CompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ConfirmRequests", "PolicyId", "dbo.Policies");
            DropForeignKey("dbo.ConfirmRequests", "EmployeeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ConfirmRequests", "Company_CompanyId", "dbo.Companies");
            DropIndex("dbo.ConfirmRequests", new[] { "Company_CompanyId" });
            DropIndex("dbo.ConfirmRequests", new[] { "PolicyId" });
            DropIndex("dbo.ConfirmRequests", new[] { "EmployeeId" });
            DropTable("dbo.ConfirmRequests");
        }
    }
}

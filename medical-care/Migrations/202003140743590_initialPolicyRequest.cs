namespace medical_care.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialPolicyRequest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PolicyRequests",
                c => new
                    {
                        RequestId = c.Int(nullable: false, identity: true),
                        RequestDate = c.DateTime(nullable: false),
                        Emi = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        PolicyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RequestId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Policies", t => t.PolicyId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.PolicyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PolicyRequests", "PolicyId", "dbo.Policies");
            DropForeignKey("dbo.PolicyRequests", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.PolicyRequests", new[] { "PolicyId" });
            DropIndex("dbo.PolicyRequests", new[] { "EmployeeId" });
            DropTable("dbo.PolicyRequests");
        }
    }
}

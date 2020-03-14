namespace medical_care.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialPolicy : DbMigration
    {
        public override void Up()
        {
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
                        Duration = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.String(),
                        DeletedAt = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PolicyId)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.Hospitals", t => t.HospitalId, cascadeDelete: true)
                .Index(t => t.CompanyId)
                .Index(t => t.HospitalId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Policies", "HospitalId", "dbo.Hospitals");
            DropForeignKey("dbo.Policies", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Policies", new[] { "HospitalId" });
            DropIndex("dbo.Policies", new[] { "CompanyId" });
            DropTable("dbo.Policies");
        }
    }
}

namespace medical_care.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PolicyOnEmps", "PolicyStart", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PolicyOnEmps", "PolicyEnd", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PolicyOnEmps", "PolicyEnd", c => c.String());
            AlterColumn("dbo.PolicyOnEmps", "PolicyStart", c => c.String());
        }
    }
}

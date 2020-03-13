namespace medical_care.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdata1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Companies", "UpdatedAt", c => c.String());
            AlterColumn("dbo.Companies", "DeletedAt", c => c.String());
            AlterColumn("dbo.Employees", "UpdatedAt", c => c.String());
            AlterColumn("dbo.Employees", "DeletedAt", c => c.String());
            AlterColumn("dbo.Hospitals", "UpdatedAt", c => c.String());
            AlterColumn("dbo.Hospitals", "DeletedAt", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Hospitals", "DeletedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Hospitals", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Employees", "DeletedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Employees", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Companies", "DeletedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Companies", "UpdatedAt", c => c.DateTime(nullable: false));
        }
    }
}

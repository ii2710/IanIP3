namespace IP3Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reports", "ReportTitle", c => c.String(maxLength: 60));
            AlterColumn("dbo.Reports", "Reporter", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Reports", "Details", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reports", "Deatails", c => c.String());
            AlterColumn("dbo.Reports", "Reporter", c => c.String());
            AlterColumn("dbo.Reports", "ReportTitle", c => c.String());
        }
    }
}

namespace IP3Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rating : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reports", "Details", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reports", "Details");
        }
    }
}

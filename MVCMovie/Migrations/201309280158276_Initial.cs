namespace IP3Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reports",
                c => new
                    {                        
                        ID = c.Int(nullable: false, identity: true),
                        Details = c.String(),
                        ReportTitle = c.String(),
                        Date = c.DateTime(nullable: false),
                        Reporter = c.String()
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Reports");
        }
    }
}

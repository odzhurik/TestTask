namespace TestTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DomainModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Domain = c.String(),
                        RecordTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UrlMeasurements",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DomainModelID = c.Int(nullable: false),
                        Url = c.String(),
                        MaxTime = c.Int(nullable: false),
                        MinTime = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DomainModels", t => t.DomainModelID, cascadeDelete: true)
                .Index(t => t.DomainModelID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UrlMeasurements", "DomainModelID", "dbo.DomainModels");
            DropIndex("dbo.UrlMeasurements", new[] { "DomainModelID" });
            DropTable("dbo.UrlMeasurements");
            DropTable("dbo.DomainModels");
        }
    }
}

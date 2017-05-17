namespace TestTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullableDomainId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UrlMeasurements", "DomainModelID", "dbo.DomainModels");
            DropIndex("dbo.UrlMeasurements", new[] { "DomainModelID" });
            AlterColumn("dbo.UrlMeasurements", "DomainModelID", c => c.Int());
            CreateIndex("dbo.UrlMeasurements", "DomainModelID");
            AddForeignKey("dbo.UrlMeasurements", "DomainModelID", "dbo.DomainModels", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UrlMeasurements", "DomainModelID", "dbo.DomainModels");
            DropIndex("dbo.UrlMeasurements", new[] { "DomainModelID" });
            AlterColumn("dbo.UrlMeasurements", "DomainModelID", c => c.Int(nullable: false));
            CreateIndex("dbo.UrlMeasurements", "DomainModelID");
            AddForeignKey("dbo.UrlMeasurements", "DomainModelID", "dbo.DomainModels", "ID", cascadeDelete: true);
        }
    }
}

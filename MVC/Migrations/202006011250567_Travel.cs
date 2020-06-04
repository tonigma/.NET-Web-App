namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Travel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlaceViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Placename = c.String(nullable: false, maxLength: 50),
                        averageAge = c.Int(nullable: false),
                        EntryTax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        distance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RoadToPlace = c.Int(nullable: false),
                        PlaceArrival = c.DateTimeOffset(nullable: false, precision: 7),
                        RegionId = c.Int(nullable: false),
                        RegionName = c.String(),
                        RegionVM_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RegionViewModels", t => t.RegionVM_Id)
                .Index(t => t.RegionVM_Id);
            
            CreateTable(
                "dbo.RegionViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegionName = c.String(nullable: false, maxLength: 50),
                        RegionLanguage = c.String(maxLength: 50),
                        Landmark = c.String(maxLength: 50),
                        RegionPopulation = c.Int(nullable: false),
                        RegionPriceOfWaterBottle = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RegionArrival = c.DateTimeOffset(nullable: false, precision: 7),
                        CountryId = c.Int(nullable: false),
                        Name = c.String(),
                        CountryVM_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CountryViewModels", t => t.CountryVM_Id)
                .Index(t => t.CountryVM_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlaceViewModels", "RegionVM_Id", "dbo.RegionViewModels");
            DropForeignKey("dbo.RegionViewModels", "CountryVM_Id", "dbo.CountryViewModels");
            DropIndex("dbo.RegionViewModels", new[] { "CountryVM_Id" });
            DropIndex("dbo.PlaceViewModels", new[] { "RegionVM_Id" });
            DropTable("dbo.RegionViewModels");
            DropTable("dbo.PlaceViewModels");
        }
    }
}

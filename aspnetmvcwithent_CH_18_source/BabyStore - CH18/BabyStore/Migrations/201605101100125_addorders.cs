namespace BabyStore.Migrations.StoreConfiguration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addorders : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderLines",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(),
                        Quantity = c.Int(nullable: false),
                        ProductName = c.String(),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        UserID = c.String(),
                        DeliveryName = c.String(),
                        DeliveryAddress_AddressLine1 = c.String(nullable: false),
                        DeliveryAddress_AddressLine2 = c.String(),
                        DeliveryAddress_Town = c.String(nullable: false),
                        DeliveryAddress_County = c.String(nullable: false),
                        DeliveryAddress_Postcode = c.String(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderLines", "ProductID", "dbo.Products");
            DropForeignKey("dbo.OrderLines", "OrderID", "dbo.Orders");
            DropIndex("dbo.OrderLines", new[] { "ProductID" });
            DropIndex("dbo.OrderLines", new[] { "OrderID" });
            DropTable("dbo.Orders");
            DropTable("dbo.OrderLines");
        }
    }
}

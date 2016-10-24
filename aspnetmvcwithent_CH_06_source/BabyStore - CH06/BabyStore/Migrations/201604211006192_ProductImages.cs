namespace BabyStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductImages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductImages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductImages");
        }
    }
}

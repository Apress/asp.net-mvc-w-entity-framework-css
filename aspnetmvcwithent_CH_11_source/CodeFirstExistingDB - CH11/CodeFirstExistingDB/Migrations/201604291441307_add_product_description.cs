namespace CodeFirstExistingDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_product_description : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Description", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Description");
        }
    }
}

namespace BookSale.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CartCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Count", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "OrderAddress", c => c.String());
            AddColumn("dbo.Orders", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "OrderDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Orders", "BookName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "BookName", c => c.String());
            DropColumn("dbo.Orders", "OrderDate");
            DropColumn("dbo.Orders", "Total");
            DropColumn("dbo.Orders", "OrderAddress");
            DropColumn("dbo.Orders", "Count");
        }
    }
}

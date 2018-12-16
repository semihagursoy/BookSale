namespace BookSale.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11InitialCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "BookQuantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "BookQuantity");
        }
    }
}

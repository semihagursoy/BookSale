namespace BookSale.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateonAdmin : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "AdminName", c => c.String(nullable: false));
            AlterColumn("dbo.Admins", "AdminPassword", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admins", "AdminPassword", c => c.String());
            AlterColumn("dbo.Admins", "AdminName", c => c.String());
        }
    }
}

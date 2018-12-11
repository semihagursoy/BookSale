namespace BookSale.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesInTheCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "ConfirmCustomerPassword", c => c.String());
            AlterColumn("dbo.Customers", "CustomerName", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "CustomerAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "CustomerMail", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "CustomerPassword", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "CustomerPassword", c => c.String());
            AlterColumn("dbo.Customers", "CustomerMail", c => c.String());
            AlterColumn("dbo.Customers", "CustomerAddress", c => c.String());
            AlterColumn("dbo.Customers", "CustomerName", c => c.String());
            DropColumn("dbo.Customers", "ConfirmCustomerPassword");
        }
    }
}

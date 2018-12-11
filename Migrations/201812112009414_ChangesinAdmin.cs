namespace BookSale.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesinAdmin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        AdminName = c.String(),
                        AdminPassword = c.String(),
                        AdminRank = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdminId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Admins");
        }
    }
}

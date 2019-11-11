namespace BudgetBuddy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WishListModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WishLists",
                c => new
                    {
                        wishListId = c.Int(nullable: false, identity: true),
                        wishListName = c.String(nullable: false),
                        wishListPrice = c.Int(nullable: false),
                        Id = c.Int(),
                    })
                .PrimaryKey(t => t.wishListId)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WishLists", "Id", "dbo.Users");
            DropIndex("dbo.WishLists", new[] { "Id" });
            DropTable("dbo.WishLists");
        }
    }
}

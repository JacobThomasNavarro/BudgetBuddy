namespace BudgetBuddy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedWishListModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WishLists", "wishListPrice", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WishLists", "wishListPrice", c => c.Int(nullable: false));
        }
    }
}

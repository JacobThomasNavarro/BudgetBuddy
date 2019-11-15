namespace BudgetBuddy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pricechangetodecimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WishLists", "wishListPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WishLists", "wishListPrice", c => c.Double(nullable: false));
        }
    }
}

namespace BudgetBuddy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class currency : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Expenses", "billPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Expenses", "billPrice", c => c.Int(nullable: false));
        }
    }
}

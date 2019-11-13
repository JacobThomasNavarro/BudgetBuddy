namespace BudgetBuddy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class savingdecimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Expenses", "savingPercentage", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Expenses", "savingPercentage", c => c.Int());
        }
    }
}

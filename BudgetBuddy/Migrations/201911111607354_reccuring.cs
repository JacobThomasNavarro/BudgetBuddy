namespace BudgetBuddy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reccuring : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Expenses", "recurringExpense", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Expenses", "recurringExpense");
        }
    }
}

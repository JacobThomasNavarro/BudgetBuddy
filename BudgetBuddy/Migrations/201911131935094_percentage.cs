namespace BudgetBuddy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class percentage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Expenses", "savingPercentage", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Expenses", "savingPercentage");
        }
    }
}

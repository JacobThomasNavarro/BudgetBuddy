namespace BudgetBuddy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class monthlyincome : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "monthlyIncome", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "monthlyIncome");
        }
    }
}

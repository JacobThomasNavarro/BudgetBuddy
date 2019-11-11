namespace BudgetBuddy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Expenses", "Id", "dbo.Users");
            DropIndex("dbo.Expenses", new[] { "Id" });
            AlterColumn("dbo.Expenses", "Id", c => c.Int());
            CreateIndex("dbo.Expenses", "Id");
            AddForeignKey("dbo.Expenses", "Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expenses", "Id", "dbo.Users");
            DropIndex("dbo.Expenses", new[] { "Id" });
            AlterColumn("dbo.Expenses", "Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Expenses", "Id");
            AddForeignKey("dbo.Expenses", "Id", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}

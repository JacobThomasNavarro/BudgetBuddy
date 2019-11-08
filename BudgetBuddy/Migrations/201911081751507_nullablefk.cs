namespace BudgetBuddy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullablefk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Expenses", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "expenseId", "dbo.Expenses");
            DropIndex("dbo.Expenses", new[] { "User_Id" });
            DropIndex("dbo.Users", new[] { "expenseId" });
            AlterColumn("dbo.Users", "expenseId", c => c.Int());
            CreateIndex("dbo.Users", "expenseId");
            AddForeignKey("dbo.Users", "expenseId", "dbo.Expenses", "expenseId");
            DropColumn("dbo.Expenses", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Expenses", "User_Id", c => c.Int());
            DropForeignKey("dbo.Users", "expenseId", "dbo.Expenses");
            DropIndex("dbo.Users", new[] { "expenseId" });
            AlterColumn("dbo.Users", "expenseId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "expenseId");
            CreateIndex("dbo.Expenses", "User_Id");
            AddForeignKey("dbo.Users", "expenseId", "dbo.Expenses", "expenseId", cascadeDelete: true);
            AddForeignKey("dbo.Expenses", "User_Id", "dbo.Users", "Id");
        }
    }
}

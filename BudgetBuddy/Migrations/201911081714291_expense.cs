namespace BudgetBuddy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class expense : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        expenseId = c.Int(nullable: false, identity: true),
                        billName = c.String(nullable: false),
                        billPrice = c.Int(nullable: false),
                        purchaseDate = c.DateTime(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.expenseId)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.Users", "expenseId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "expenseId");
            AddForeignKey("dbo.Users", "expenseId", "dbo.Expenses", "expenseId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expenses", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "expenseId", "dbo.Expenses");
            DropIndex("dbo.Users", new[] { "expenseId" });
            DropIndex("dbo.Expenses", new[] { "User_Id" });
            DropColumn("dbo.Users", "expenseId");
            DropTable("dbo.Expenses");
        }
    }
}

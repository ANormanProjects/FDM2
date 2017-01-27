namespace BudgieDatabaseLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class accountOwnerId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accounts", "accountOwner_id", "dbo.BudgieUsers");
            DropIndex("dbo.Accounts", new[] { "accountOwner_id" });
            RenameColumn(table: "dbo.Accounts", name: "accountOwner_id", newName: "accountOwnerId");
            AlterColumn("dbo.Accounts", "accountOwnerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Accounts", "accountOwnerId");
            AddForeignKey("dbo.Accounts", "accountOwnerId", "dbo.BudgieUsers", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "accountOwnerId", "dbo.BudgieUsers");
            DropIndex("dbo.Accounts", new[] { "accountOwnerId" });
            AlterColumn("dbo.Accounts", "accountOwnerId", c => c.Int());
            RenameColumn(table: "dbo.Accounts", name: "accountOwnerId", newName: "accountOwner_id");
            CreateIndex("dbo.Accounts", "accountOwner_id");
            AddForeignKey("dbo.Accounts", "accountOwner_id", "dbo.BudgieUsers", "id");
        }
    }
}

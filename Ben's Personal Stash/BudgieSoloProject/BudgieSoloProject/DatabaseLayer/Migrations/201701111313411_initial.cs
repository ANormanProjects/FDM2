namespace BudgieDatabaseLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        accountNumber = c.String(),
                        balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        budget = c.Decimal(nullable: false, precision: 18, scale: 2),
                        accountOwner_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.BudgieUsers", t => t.accountOwner_id)
                .Index(t => t.accountOwner_id);
            
            CreateTable(
                "dbo.BudgieUsers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        lastName = c.String(),
                        emailAddress = c.String(),
                        dob = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "accountOwner_id", "dbo.BudgieUsers");
            DropIndex("dbo.Accounts", new[] { "accountOwner_id" });
            DropTable("dbo.BudgieUsers");
            DropTable("dbo.Accounts");
        }
    }
}

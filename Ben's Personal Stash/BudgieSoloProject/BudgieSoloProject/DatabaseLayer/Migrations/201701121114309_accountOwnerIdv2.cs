namespace BudgieDatabaseLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class accountOwnerIdv2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BudgieUsers", "dob", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BudgieUsers", "dob", c => c.Int(nullable: false));
        }
    }
}

namespace BudgieDatabaseLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BudgieUsers", "roles", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BudgieUsers", "roles");
        }
    }
}

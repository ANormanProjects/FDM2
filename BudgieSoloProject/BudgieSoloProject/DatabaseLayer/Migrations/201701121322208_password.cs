namespace BudgieDatabaseLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class password : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BudgieUsers", "password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BudgieUsers", "password");
        }
    }
}

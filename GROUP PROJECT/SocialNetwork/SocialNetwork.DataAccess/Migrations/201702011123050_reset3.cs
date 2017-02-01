namespace SocialNetwork.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reset3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "likes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "likes");
        }
    }
}

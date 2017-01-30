namespace SocialNetwork.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intial3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "post_postId", c => c.Int());
            AddColumn("dbo.Comments", "user_userId", c => c.Int());
            CreateIndex("dbo.Comments", "post_postId");
            CreateIndex("dbo.Comments", "user_userId");
            AddForeignKey("dbo.Comments", "post_postId", "dbo.Posts", "postId");
            AddForeignKey("dbo.Comments", "user_userId", "dbo.Users", "userId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "user_userId", "dbo.Users");
            DropForeignKey("dbo.Comments", "post_postId", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "user_userId" });
            DropIndex("dbo.Comments", new[] { "post_postId" });
            DropColumn("dbo.Comments", "user_userId");
            DropColumn("dbo.Comments", "post_postId");
        }
    }
}

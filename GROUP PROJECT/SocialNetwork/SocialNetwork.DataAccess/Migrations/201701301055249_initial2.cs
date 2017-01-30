namespace SocialNetwork.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        commentId = c.Int(nullable: false, identity: true),
                        content = c.String(),
                    })
                .PrimaryKey(t => t.commentId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        postId = c.Int(nullable: false, identity: true),
                        time = c.DateTime(nullable: false),
                        likes = c.Int(nullable: false),
                        title = c.String(),
                        user_userId = c.Int(),
                    })
                .PrimaryKey(t => t.postId)
                .ForeignKey("dbo.Users", t => t.user_userId)
                .Index(t => t.user_userId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        userId = c.Int(nullable: false, identity: true),
                        username = c.String(),
                        password = c.String(),
                        fullName = c.String(),
                        gender = c.String(),
                    })
                .PrimaryKey(t => t.userId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "user_userId", "dbo.Users");
            DropIndex("dbo.Posts", new[] { "user_userId" });
            DropTable("dbo.Users");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
        }
    }
}

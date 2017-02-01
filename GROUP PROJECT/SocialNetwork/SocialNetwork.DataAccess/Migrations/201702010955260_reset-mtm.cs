namespace SocialNetwork.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class resetmtm : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        commentId = c.Int(nullable: false, identity: true),
                        content = c.String(),
                        post_postId = c.Int(),
                        user_userId = c.Int(),
                    })
                .PrimaryKey(t => t.commentId)
                .ForeignKey("dbo.Posts", t => t.post_postId)
                .ForeignKey("dbo.Users", t => t.user_userId)
                .Index(t => t.post_postId)
                .Index(t => t.user_userId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        postId = c.Int(nullable: false, identity: true),
                        time = c.DateTime(nullable: false),
                        likes = c.Int(nullable: false),
                        title = c.String(),
                        language = c.String(),
                        content = c.String(),
                        code = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        group_groupID = c.Int(),
                        user_userId = c.Int(),
                    })
                .PrimaryKey(t => t.postId)
                .ForeignKey("dbo.Groups", t => t.group_groupID)
                .ForeignKey("dbo.Users", t => t.user_userId)
                .Index(t => t.group_groupID)
                .Index(t => t.user_userId);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        groupID = c.Int(nullable: false, identity: true),
                        groupName = c.String(),
                        owner_userId = c.Int(),
                    })
                .PrimaryKey(t => t.groupID)
                .ForeignKey("dbo.Users", t => t.owner_userId)
                .Index(t => t.owner_userId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        userId = c.Int(nullable: false, identity: true),
                        username = c.String(),
                        password = c.String(),
                        fullName = c.String(),
                        gender = c.String(),
                        User_userId = c.Int(),
                    })
                .PrimaryKey(t => t.userId)
                .ForeignKey("dbo.Users", t => t.User_userId)
                .Index(t => t.User_userId);
            
            CreateTable(
                "dbo.UserGroups",
                c => new
                    {
                        GroupRefId = c.Int(nullable: false),
                        UserRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GroupRefId, t.UserRefId })
                .ForeignKey("dbo.Groups", t => t.GroupRefId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserRefId, cascadeDelete: true)
                .Index(t => t.GroupRefId)
                .Index(t => t.UserRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "user_userId", "dbo.Users");
            DropForeignKey("dbo.Posts", "user_userId", "dbo.Users");
            DropForeignKey("dbo.Posts", "group_groupID", "dbo.Groups");
            DropForeignKey("dbo.UserGroups", "UserRefId", "dbo.Users");
            DropForeignKey("dbo.UserGroups", "GroupRefId", "dbo.Groups");
            DropForeignKey("dbo.Groups", "owner_userId", "dbo.Users");
            DropForeignKey("dbo.Posts", "User_userId", "dbo.Users");
            DropForeignKey("dbo.Users", "User_userId", "dbo.Users");
            DropForeignKey("dbo.Posts", "Group_groupID", "dbo.Groups");
            DropForeignKey("dbo.Comments", "post_postId", "dbo.Posts");
            DropIndex("dbo.UserGroups", new[] { "UserRefId" });
            DropIndex("dbo.UserGroups", new[] { "GroupRefId" });
            DropIndex("dbo.Users", new[] { "User_userId" });
            DropIndex("dbo.Groups", new[] { "owner_userId" });
            DropIndex("dbo.Posts", new[] { "user_userId" });
            DropIndex("dbo.Posts", new[] { "group_groupID" });
            DropIndex("dbo.Posts", new[] { "User_userId" });
            DropIndex("dbo.Posts", new[] { "Group_groupID" });
            DropIndex("dbo.Comments", new[] { "user_userId" });
            DropIndex("dbo.Comments", new[] { "post_postId" });
            DropTable("dbo.UserGroups");
            DropTable("dbo.Users");
            DropTable("dbo.Groups");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
        }
    }
}

namespace SocialNetwork.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reset : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        commentId = c.Int(nullable: false, identity: true),
                        content = c.String(),
                        likes = c.Int(nullable: false),
                        post_postId = c.Int(),
                        user_userId = c.Int(),
                    })
                .PrimaryKey(t => t.commentId)
                .ForeignKey("dbo.Users", t => t.user_userId)
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
                        role = c.String(),
                    })
                .PrimaryKey(t => t.userId);
            
            CreateTable(
                "dbo.UserFriends",
                c => new
                    {
                        UserRefId = c.Int(nullable: false),
                        FriendRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserRefId, t.FriendRefId })
                .ForeignKey("dbo.Users", t => t.UserRefId)
                .ForeignKey("dbo.Users", t => t.FriendRefId)
                .Index(t => t.UserRefId)
                .Index(t => t.FriendRefId);
            
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
            
            CreateTable(
                "dbo.UserPosts",
                c => new
                    {
                        postId = c.Int(nullable: false, identity: true),
                        user_userId = c.Int(),
                        time = c.DateTime(nullable: false),
                        likes = c.Int(nullable: false),
                        title = c.String(),
                        language = c.String(),
                        content = c.String(),
                        code = c.String(),
                    })
                .PrimaryKey(t => t.postId)
                .ForeignKey("dbo.Users", t => t.user_userId)
                .Index(t => t.user_userId);
            
            CreateTable(
                "dbo.GroupPosts",
                c => new
                    {
                        postId = c.Int(nullable: false, identity: true),
                        group_groupID = c.Int(),
                        time = c.DateTime(nullable: false),
                        likes = c.Int(nullable: false),
                        title = c.String(),
                        language = c.String(),
                        content = c.String(),
                        code = c.String(),
                    })
                .PrimaryKey(t => t.postId)
                .ForeignKey("dbo.Groups", t => t.group_groupID)
                .Index(t => t.group_groupID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroupPosts", "group_groupID", "dbo.Groups");
            DropForeignKey("dbo.UserPosts", "user_userId", "dbo.Users");
            DropForeignKey("dbo.Comments", "user_userId", "dbo.Users");
            DropForeignKey("dbo.UserGroups", "UserRefId", "dbo.Users");
            DropForeignKey("dbo.UserGroups", "GroupRefId", "dbo.Groups");
            DropForeignKey("dbo.Groups", "owner_userId", "dbo.Users");
            DropForeignKey("dbo.UserFriends", "FriendRefId", "dbo.Users");
            DropForeignKey("dbo.UserFriends", "UserRefId", "dbo.Users");
            DropIndex("dbo.GroupPosts", new[] { "group_groupID" });
            DropIndex("dbo.UserPosts", new[] { "user_userId" });
            DropIndex("dbo.UserGroups", new[] { "UserRefId" });
            DropIndex("dbo.UserGroups", new[] { "GroupRefId" });
            DropIndex("dbo.UserFriends", new[] { "FriendRefId" });
            DropIndex("dbo.UserFriends", new[] { "UserRefId" });
            DropIndex("dbo.Groups", new[] { "owner_userId" });
            DropIndex("dbo.Comments", new[] { "user_userId" });
            DropTable("dbo.GroupPosts");
            DropTable("dbo.UserPosts");
            DropTable("dbo.UserGroups");
            DropTable("dbo.UserFriends");
            DropTable("dbo.Users");
            DropTable("dbo.Groups");
            DropTable("dbo.Comments");
        }
    }
}

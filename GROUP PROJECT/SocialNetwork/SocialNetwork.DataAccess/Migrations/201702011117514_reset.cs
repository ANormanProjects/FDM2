namespace SocialNetwork.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reset : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "User_userId", "dbo.Users");
            DropForeignKey("dbo.Users", "Group_groupID", "dbo.Groups");
            DropIndex("dbo.Users", new[] { "User_userId" });
            DropIndex("dbo.Users", new[] { "Group_groupID" });
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
            
            AddColumn("dbo.Users", "role", c => c.String());
            DropColumn("dbo.Users", "User_userId");
            DropColumn("dbo.Users", "Group_groupID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Group_groupID", c => c.Int());
            AddColumn("dbo.Users", "User_userId", c => c.Int());
            DropForeignKey("dbo.UserGroups", "UserRefId", "dbo.Users");
            DropForeignKey("dbo.UserGroups", "GroupRefId", "dbo.Groups");
            DropForeignKey("dbo.UserFriends", "FriendRefId", "dbo.Users");
            DropForeignKey("dbo.UserFriends", "UserRefId", "dbo.Users");
            DropIndex("dbo.UserGroups", new[] { "UserRefId" });
            DropIndex("dbo.UserGroups", new[] { "GroupRefId" });
            DropIndex("dbo.UserFriends", new[] { "FriendRefId" });
            DropIndex("dbo.UserFriends", new[] { "UserRefId" });
            DropColumn("dbo.Users", "role");
            DropTable("dbo.UserGroups");
            DropTable("dbo.UserFriends");
            CreateIndex("dbo.Users", "Group_groupID");
            CreateIndex("dbo.Users", "User_userId");
            AddForeignKey("dbo.Users", "Group_groupID", "dbo.Groups", "groupID");
            AddForeignKey("dbo.Users", "User_userId", "dbo.Users", "userId");
        }
    }
}

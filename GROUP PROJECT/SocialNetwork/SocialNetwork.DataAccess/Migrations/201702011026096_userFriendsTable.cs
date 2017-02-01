namespace SocialNetwork.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userFriendsTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "User_userId", "dbo.Users");
            DropIndex("dbo.Users", new[] { "User_userId" });
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
            
            DropColumn("dbo.Users", "User_userId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "User_userId", c => c.Int());
            DropForeignKey("dbo.UserFriends", "FriendRefId", "dbo.Users");
            DropForeignKey("dbo.UserFriends", "UserRefId", "dbo.Users");
            DropIndex("dbo.UserFriends", new[] { "FriendRefId" });
            DropIndex("dbo.UserFriends", new[] { "UserRefId" });
            DropTable("dbo.UserFriends");
            CreateIndex("dbo.Users", "User_userId");
            AddForeignKey("dbo.Users", "User_userId", "dbo.Users", "userId");
        }
    }
}

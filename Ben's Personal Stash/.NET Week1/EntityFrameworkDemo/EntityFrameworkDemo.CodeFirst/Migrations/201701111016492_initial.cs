namespace EntityFrameworkDemo.CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brokers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        companyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Companies", t => t.companyId, cascadeDelete: true)
                .Index(t => t.companyId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Brokers", "companyId", "dbo.Companies");
            DropIndex("dbo.Brokers", new[] { "companyId" });
            DropTable("dbo.Companies");
            DropTable("dbo.Brokers");
        }
    }
}

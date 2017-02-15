namespace E_Commerce_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Baskets",
                c => new
                    {
                        basketId = c.Int(nullable: false, identity: true),
                        basketName = c.String(),
                    })
                .PrimaryKey(t => t.basketId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Items");
            DropTable("dbo.Baskets");
        }
    }
}

namespace E_Commerce_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialv2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "Basket_basketId", c => c.Int());
            CreateIndex("dbo.Items", "Basket_basketId");
            AddForeignKey("dbo.Items", "Basket_basketId", "dbo.Baskets", "basketId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "Basket_basketId", "dbo.Baskets");
            DropIndex("dbo.Items", new[] { "Basket_basketId" });
            DropColumn("dbo.Items", "Basket_basketId");
        }
    }
}

namespace MazadMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Multi_Description_Id", "dbo.Multi_Description");
            DropIndex("dbo.Products", new[] { "Multi_Description_Id" });
            CreateTable(
                "dbo.paymentConfirmations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        userId = c.String(),
                        ProductsId = c.Int(nullable: false),
                        depositValue = c.String(),
                        cCV = c.String(),
                        visaCard = c.String(),
                        cardExpirationDate = c.DateTime(nullable: false),
                        ProductsAuction_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductsAuctions", t => t.ProductsAuction_Id)
                .Index(t => t.ProductsAuction_Id);
            
            AddColumn("dbo.Products", "bankAccountNumber", c => c.String());
            AddColumn("dbo.Products", "paymentConfirmation_Id", c => c.Int());
            AddColumn("dbo.ProductsAuctions", "valueUP", c => c.Double(nullable: false));
            AddColumn("dbo.ProductsAuctions", "limitPrice", c => c.Double(nullable: false));
            CreateIndex("dbo.Products", "paymentConfirmation_Id");
            AddForeignKey("dbo.Products", "paymentConfirmation_Id", "dbo.paymentConfirmations", "Id");
            DropColumn("dbo.Products", "Multi_Description_Id");
            DropTable("dbo.Multi_Description");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Multi_Description",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        description1 = c.String(nullable: false),
                        description2 = c.String(nullable: false),
                        description3 = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "Multi_Description_Id", c => c.Int());
            DropForeignKey("dbo.Products", "paymentConfirmation_Id", "dbo.paymentConfirmations");
            DropForeignKey("dbo.paymentConfirmations", "ProductsAuction_Id", "dbo.ProductsAuctions");
            DropIndex("dbo.paymentConfirmations", new[] { "ProductsAuction_Id" });
            DropIndex("dbo.Products", new[] { "paymentConfirmation_Id" });
            DropColumn("dbo.ProductsAuctions", "limitPrice");
            DropColumn("dbo.ProductsAuctions", "valueUP");
            DropColumn("dbo.Products", "paymentConfirmation_Id");
            DropColumn("dbo.Products", "bankAccountNumber");
            DropTable("dbo.paymentConfirmations");
            CreateIndex("dbo.Products", "Multi_Description_Id");
            AddForeignKey("dbo.Products", "Multi_Description_Id", "dbo.Multi_Description", "Id");
        }
    }
}

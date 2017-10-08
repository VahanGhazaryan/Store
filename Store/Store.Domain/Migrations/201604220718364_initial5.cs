namespace Store.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductSubCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                        ProductCategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategories", t => t.ProductCategoryId)
                .Index(t => t.ProductCategoryId);
            
            CreateTable(
                "dbo.ProductPropertyValues",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        ProductProperyId = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProductProperties", t => t.ProductProperyId)
                .Index(t => t.ProductProperyId);
            
            AddColumn("dbo.ProductProperties", "ProductSubCategoryId", c => c.Int());
            CreateIndex("dbo.ProductProperties", "ProductSubCategoryId");
            AddForeignKey("dbo.ProductProperties", "ProductSubCategoryId", "dbo.ProductCategories", "Id");
            AddForeignKey("dbo.ProductProperties", "ProductSubCategoryId", "dbo.ProductSubCategories", "Id");
            DropColumn("dbo.ProductProperties", "Value");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductProperties", "Value", c => c.String());
            DropForeignKey("dbo.ProductProperties", "ProductSubCategoryId", "dbo.ProductSubCategories");
            DropForeignKey("dbo.ProductProperties", "ProductSubCategoryId", "dbo.ProductCategories");
            DropForeignKey("dbo.ProductPropertyValues", "ProductProperyId", "dbo.ProductProperties");
            DropForeignKey("dbo.ProductSubCategories", "ProductCategoryId", "dbo.ProductCategories");
            DropIndex("dbo.ProductPropertyValues", new[] { "ProductProperyId" });
            DropIndex("dbo.ProductProperties", new[] { "ProductSubCategoryId" });
            DropIndex("dbo.ProductSubCategories", new[] { "ProductCategoryId" });
            DropColumn("dbo.ProductProperties", "ProductSubCategoryId");
            DropTable("dbo.ProductPropertyValues");
            DropTable("dbo.ProductSubCategories");
            DropTable("dbo.ProductCategories");
        }
    }
}

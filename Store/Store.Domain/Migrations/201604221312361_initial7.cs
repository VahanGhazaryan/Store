namespace Store.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductCategories", "ImagePath", c => c.String());
            AddColumn("dbo.ProductSubCategories", "ImagePath", c => c.String());
            DropColumn("dbo.ProductCategories", "Image");
            DropColumn("dbo.ProductSubCategories", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductSubCategories", "Image", c => c.String());
            AddColumn("dbo.ProductCategories", "Image", c => c.String());
            DropColumn("dbo.ProductSubCategories", "ImagePath");
            DropColumn("dbo.ProductCategories", "ImagePath");
        }
    }
}

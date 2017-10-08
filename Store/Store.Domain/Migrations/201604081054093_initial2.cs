namespace Store.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        UserID = c.String(nullable: false, maxLength: 128),
                        AddrType = c.Int(nullable: false),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        Country = c.String(),
                        Phone = c.String(),
                        Gender = c.String(),
                    })
                .PrimaryKey(t => new { t.UserID, t.AddrType });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Addresses");
        }
    }
}

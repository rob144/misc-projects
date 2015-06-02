namespace UniversityLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 20),
                        EmailAddress = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.User");
        }
    }
}

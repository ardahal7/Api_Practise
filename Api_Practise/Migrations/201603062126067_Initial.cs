namespace Api_Practise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Footballers",
                c => new
                    {
                        FootballersID = c.Int(nullable: false, identity: true),
                        kitnumber = c.Int(nullable: false),
                        club = c.String(nullable: false),
                        position = c.String(nullable: false),
                        nationality = c.String(nullable: false),
                        name = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 100),
                        username = c.String(nullable: false),
                        ConfirmPassword = c.String(),
                    })
                .PrimaryKey(t => t.FootballersID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Footballers");
        }
    }
}

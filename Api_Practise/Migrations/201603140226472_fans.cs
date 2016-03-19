namespace Api_Practise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fans : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.footballFans",
                c => new
                    {
                        FootballersID = c.Int(nullable: false),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.FootballersID)
                .ForeignKey("dbo.Footballers", t => t.FootballersID)
                .Index(t => t.FootballersID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.footballFans", "FootballersID", "dbo.Footballers");
            DropIndex("dbo.footballFans", new[] { "FootballersID" });
            DropTable("dbo.footballFans");
        }
    }
}

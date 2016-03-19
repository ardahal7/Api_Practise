namespace Api_Practise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fansAgain : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.footballFans", "FootballersID", "dbo.Footballers");
            DropPrimaryKey("dbo.footballFans");
            AddColumn("dbo.footballFans", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.footballFans", "ID");
            AddForeignKey("dbo.footballFans", "FootballersID", "dbo.Footballers", "FootballersID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.footballFans", "FootballersID", "dbo.Footballers");
            DropPrimaryKey("dbo.footballFans");
            DropColumn("dbo.footballFans", "ID");
            AddPrimaryKey("dbo.footballFans", "FootballersID");
            AddForeignKey("dbo.footballFans", "FootballersID", "dbo.Footballers", "FootballersID");
        }
    }
}

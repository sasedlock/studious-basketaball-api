namespace CommandAndQuery.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingPlayerToMakeBasketballFkNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Players", "BasketballTeamId", "dbo.BasketballTeams");
            DropIndex("dbo.Players", new[] { "BasketballTeamId" });
            AlterColumn("dbo.Players", "BasketballTeamId", c => c.Int());
            CreateIndex("dbo.Players", "BasketballTeamId");
            AddForeignKey("dbo.Players", "BasketballTeamId", "dbo.BasketballTeams", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Players", "BasketballTeamId", "dbo.BasketballTeams");
            DropIndex("dbo.Players", new[] { "BasketballTeamId" });
            AlterColumn("dbo.Players", "BasketballTeamId", c => c.Int(nullable: false));
            CreateIndex("dbo.Players", "BasketballTeamId");
            AddForeignKey("dbo.Players", "BasketballTeamId", "dbo.BasketballTeams", "Id", cascadeDelete: true);
        }
    }
}

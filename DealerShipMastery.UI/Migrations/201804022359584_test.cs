namespace DealerShipMastery.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "StateID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "StateID", c => c.String());
        }
    }
}

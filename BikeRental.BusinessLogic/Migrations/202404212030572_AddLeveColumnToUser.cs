namespace BikeRental.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLeveColumnToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserDBTables", "Level", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserDBTables", "Level");
        }
    }
}

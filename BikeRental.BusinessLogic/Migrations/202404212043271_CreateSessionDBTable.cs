﻿namespace BikeRental.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateSessionDBTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.SessionDBTables",
                    c => new
                    {
                        SessionId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 30),
                        CookieString = c.String(nullable: false),
                        ExpireTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SessionId);
        }

        public override void Down()
        {
            DropTable("dbo.SessionDBTables");
        }
    }
}

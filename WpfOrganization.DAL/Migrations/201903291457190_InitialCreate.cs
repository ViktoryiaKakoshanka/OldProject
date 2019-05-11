namespace WpfOrganization.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CableTVProblems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameOfProblem = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShortNameOfCityType = c.String(),
                        CityName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Masters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Surname = c.String(),
                        Name = c.String(),
                        Patronymic = c.String(),
                        WorkPhone = c.String(),
                        SecondWorkPhone = c.String(),
                        HomePhone = c.String(),
                        SecondHomePhone = c.String(),
                        MobilePhone = c.String(),
                        SecondMobilePhone = c.String(),
                        Brigade = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderRepairAndRestructions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ResponsibleMasterId = c.Int(),
                        MasterPerformerId = c.Int(),
                        CityId = c.Int(),
                        StreetId = c.Int(),
                        HouseNumber = c.String(),
                        ApartmentNumber = c.String(),
                        Problem = c.String(),
                        Remark = c.String(),
                        Status = c.Byte(nullable: false),
                        DateOfExecution = c.DateTime(nullable: false),
                        DateOfCallback = c.DateTime(nullable: false),
                        DateOfCreation = c.DateTime(nullable: false),
                        EstimatedCompletionDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .ForeignKey("dbo.Streets", t => t.StreetId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Masters", t => t.MasterPerformerId)
                .ForeignKey("dbo.Masters", t => t.ResponsibleMasterId)
                .Index(t => t.UserId)
                .Index(t => t.ResponsibleMasterId)
                .Index(t => t.MasterPerformerId)
                .Index(t => t.CityId)
                .Index(t => t.StreetId);
            
            CreateTable(
                "dbo.Streets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StreetName = c.String(),
                        StreetTypes = c.Int(nullable: false),
                        City_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .Index(t => t.City_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        LoggedIn = c.Boolean(nullable: false),
                        AdminRole = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserActions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateOfAction = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.OrderOnCableTVs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubscriberId = c.Int(nullable: false),
                        UserLocation = c.String(),
                        PhoneNumber = c.String(),
                        Remark = c.String(),
                        CableTVProblemId = c.Int(),
                        NonStandardProblem = c.String(),
                        MasterId = c.Int(),
                        OrderStatus = c.Byte(nullable: false),
                        ExecutionDate = c.DateTime(),
                        CallbackDate = c.DateTime(),
                        IsCollectiveOrder = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        EstimatedCompletionDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Masters", t => t.MasterId)
                .ForeignKey("dbo.CableTVProblems", t => t.CableTVProblemId)
                .ForeignKey("dbo.Subscribers", t => t.SubscriberId, cascadeDelete: true)
                .Index(t => t.SubscriberId)
                .Index(t => t.CableTVProblemId)
                .Index(t => t.MasterId);
            
            CreateTable(
                "dbo.Subscribers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumberOfContract = c.Int(nullable: false),
                        ContractDate = c.DateTime(nullable: false),
                        Surname = c.String(),
                        Name = c.String(),
                        Patronymic = c.String(),
                        HomePhone = c.String(),
                        MobilePhone = c.String(),
                        SecondMobilePhone = c.String(),
                        RelationshipType = c.Int(nullable: false),
                        CityId = c.Int(),
                        StreetId = c.Int(),
                        HouseNumber = c.String(),
                        ApartmentNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .ForeignKey("dbo.Streets", t => t.StreetId)
                .Index(t => t.NumberOfContract, unique: true)
                .Index(t => t.CityId)
                .Index(t => t.StreetId);
            
            CreateTable(
                "dbo.SubscriberRelationships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RelationshipDate = c.DateTime(nullable: false),
                        SubscriberId = c.Int(nullable: false),
                        RelationshipType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subscribers", t => t.SubscriberId, cascadeDelete: true)
                .Index(t => t.SubscriberId);
            
            CreateTable(
                "dbo.MasterCities",
                c => new
                    {
                        Master_Id = c.Int(nullable: false),
                        City_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Master_Id, t.City_Id })
                .ForeignKey("dbo.Masters", t => t.Master_Id, cascadeDelete: true)
                .ForeignKey("dbo.Cities", t => t.City_Id, cascadeDelete: true)
                .Index(t => t.Master_Id)
                .Index(t => t.City_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Streets", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.OrderRepairAndRestructions", "ResponsibleMasterId", "dbo.Masters");
            DropForeignKey("dbo.Subscribers", "StreetId", "dbo.Streets");
            DropForeignKey("dbo.SubscriberRelationships", "SubscriberId", "dbo.Subscribers");
            DropForeignKey("dbo.OrderOnCableTVs", "SubscriberId", "dbo.Subscribers");
            DropForeignKey("dbo.Subscribers", "CityId", "dbo.Cities");
            DropForeignKey("dbo.OrderOnCableTVs", "CableTVProblemId", "dbo.CableTVProblems");
            DropForeignKey("dbo.OrderOnCableTVs", "MasterId", "dbo.Masters");
            DropForeignKey("dbo.OrderRepairAndRestructions", "MasterPerformerId", "dbo.Masters");
            DropForeignKey("dbo.OrderRepairAndRestructions", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserActions", "UserId", "dbo.Users");
            DropForeignKey("dbo.OrderRepairAndRestructions", "StreetId", "dbo.Streets");
            DropForeignKey("dbo.OrderRepairAndRestructions", "CityId", "dbo.Cities");
            DropForeignKey("dbo.MasterCities", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.MasterCities", "Master_Id", "dbo.Masters");
            DropIndex("dbo.MasterCities", new[] { "City_Id" });
            DropIndex("dbo.MasterCities", new[] { "Master_Id" });
            DropIndex("dbo.SubscriberRelationships", new[] { "SubscriberId" });
            DropIndex("dbo.Subscribers", new[] { "StreetId" });
            DropIndex("dbo.Subscribers", new[] { "CityId" });
            DropIndex("dbo.Subscribers", new[] { "NumberOfContract" });
            DropIndex("dbo.OrderOnCableTVs", new[] { "MasterId" });
            DropIndex("dbo.OrderOnCableTVs", new[] { "CableTVProblemId" });
            DropIndex("dbo.OrderOnCableTVs", new[] { "SubscriberId" });
            DropIndex("dbo.UserActions", new[] { "UserId" });
            DropIndex("dbo.Streets", new[] { "City_Id" });
            DropIndex("dbo.OrderRepairAndRestructions", new[] { "StreetId" });
            DropIndex("dbo.OrderRepairAndRestructions", new[] { "CityId" });
            DropIndex("dbo.OrderRepairAndRestructions", new[] { "MasterPerformerId" });
            DropIndex("dbo.OrderRepairAndRestructions", new[] { "ResponsibleMasterId" });
            DropIndex("dbo.OrderRepairAndRestructions", new[] { "UserId" });
            DropTable("dbo.MasterCities");
            DropTable("dbo.SubscriberRelationships");
            DropTable("dbo.Subscribers");
            DropTable("dbo.OrderOnCableTVs");
            DropTable("dbo.UserActions");
            DropTable("dbo.Users");
            DropTable("dbo.Streets");
            DropTable("dbo.OrderRepairAndRestructions");
            DropTable("dbo.Masters");
            DropTable("dbo.Cities");
            DropTable("dbo.CableTVProblems");
        }
    }
}

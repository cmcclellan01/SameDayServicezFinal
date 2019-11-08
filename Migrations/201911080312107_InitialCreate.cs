namespace SameDayServicezFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {

            return;



            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        MainCatName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContractorCustomerCategories",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ContractorCustomerId = c.String(),
                        MainCatId = c.Long(nullable: false),
                        SubCatId = c.Long(nullable: false),
                        SubCatName = c.String(),
                        MainCatName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LoginHistory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        LoginTime = c.DateTime(nullable: false),
                        LogoutTime = c.DateTime(),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectsId = c.Long(nullable: false, identity: true),
                        ProjectsUsersId = c.String(nullable: false),
                        ProjectTitle = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        IsDraft = c.Boolean(nullable: false),
                        Address = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        ZipCode = c.String(nullable: false, maxLength: 5),
                        InfoTabOpen = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        ProjectCompensationPackageId = c.Long(nullable: false),
                        latitude = c.Double(nullable: false),
                        longitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectsId);
            
            CreateTable(
                "dbo.ProjectAssignment",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                        UsersId = c.String(),
                        ProjectId = c.Long(nullable: false),
                        ProjectOwner = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProjectCategories",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProjectsUsersId = c.String(),
                        ProjectsMainCatId = c.Long(nullable: false),
                        ProjectsSubCatId = c.Long(nullable: false),
                        ProjectsId = c.Long(nullable: false),
                        ProjectsSubCatName = c.String(),
                        ProjectsMainCatName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProjectCompensationPackage",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UsersId = c.String(),
                        ProjectId = c.Long(nullable: false),
                        ProjectCompensationType = c.Long(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ByTheHourRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ByTheProjectRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartingBidRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EndingBidRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FloatingBidRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartingBidDate = c.DateTime(nullable: false),
                        EndingBidDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProjectCompensations",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CompensationTypeText = c.String(),
                        CompensationTypeValue = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProjectDocuments",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProjectId = c.Long(nullable: false),
                        ImageName = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        UsersId = c.String(),
                        ImageComment = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.StateAndCityInfo",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        State = c.String(),
                        City = c.String(),
                        County = c.String(),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subcategories",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        MainCatId = c.Long(nullable: false),
                        SubCatNames = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        BirthDate = c.String(),
                        Bio = c.String(),
                        IsInContractorMode = c.Boolean(nullable: false),
                        IsInCustomerMode = c.Boolean(nullable: false),
                        PercentDone = c.Int(nullable: false),
                        InfoTabOpen = c.String(),
                        ProfileImage = c.String(),
                        IdImage = c.String(),
                        latitude = c.Double(nullable: false),
                        longitude = c.Double(nullable: false),
                        ByTheHourRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Rating = c.Int(nullable: false),
                        RatingClass = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Subcategories");
            DropTable("dbo.StateAndCityInfo");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ProjectDocuments");
            DropTable("dbo.ProjectCompensations");
            DropTable("dbo.ProjectCompensationPackage");
            DropTable("dbo.ProjectCategories");
            DropTable("dbo.ProjectAssignment");
            DropTable("dbo.Projects");
            DropTable("dbo.LoginHistory");
            DropTable("dbo.ContractorCustomerCategories");
            DropTable("dbo.Categories");
        }
    }
}

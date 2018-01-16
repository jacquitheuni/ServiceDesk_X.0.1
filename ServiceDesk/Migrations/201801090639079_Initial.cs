namespace ServiceDesk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AgentDepartments",
                c => new
                    {
                        AgentDepartmentId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AgentDepartmentId);
            
            CreateTable(
                "dbo.BusinessHours",
                c => new
                    {
                        BusinessHoursId = c.Int(nullable: false, identity: true),
                        AgentDepartmentId = c.String(nullable: false),
                        Day = c.Int(nullable: false),
                        StartTime = c.String(nullable: false),
                        EndTime = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BusinessHoursId);
            
            CreateTable(
                "dbo.BusinessUnits",
                c => new
                    {
                        BusinessUnitId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        isActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BusinessUnitId);
            
            CreateTable(
                "dbo.BusinessUnitAccesses",
                c => new
                    {
                        BusinessUnitAccessId = c.Int(nullable: false, identity: true),
                        BusinessUnitId = c.Int(nullable: false),
                        RoleId = c.String(),
                    })
                .PrimaryKey(t => t.BusinessUnitAccessId)
                .ForeignKey("dbo.BusinessUnits", t => t.BusinessUnitId, cascadeDelete: true)
                .Index(t => t.BusinessUnitId);
            
            CreateTable(
                "dbo.BusinessUnitManagements",
                c => new
                    {
                        BusinessUnitManagementiD = c.Int(nullable: false, identity: true),
                        BusinessUnitId = c.Int(nullable: false),
                        TeamLeader = c.String(),
                        GeneralManager = c.String(),
                        HOD = c.String(),
                    })
                .PrimaryKey(t => t.BusinessUnitManagementiD)
                .ForeignKey("dbo.BusinessUnits", t => t.BusinessUnitId, cascadeDelete: true)
                .Index(t => t.BusinessUnitId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        PreferredName = c.String(),
                        Division = c.Int(nullable: false),
                        BusinessUnitId = c.Int(nullable: false),
                        ReportingManager = c.String(nullable: false),
                        kingdomName = c.String(nullable: false),
                        ShadowUser = c.String(nullable: false),
                        Gender = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        isActive = c.Boolean(nullable: false),
                        isManager = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.BusinessUnits", t => t.BusinessUnitId, cascadeDelete: true)
                .Index(t => t.BusinessUnitId);
            
            CreateTable(
                "dbo.EmployeeRequests",
                c => new
                    {
                        EmployeeRequestId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        RequestId = c.Int(nullable: false),
                        EffectiveDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeRequestId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Requests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.RequestId);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        RequestID = c.Int(nullable: false, identity: true),
                        RequestLinkID = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Subject = c.String(),
                        Description = c.String(),
                        Category = c.Int(nullable: false),
                        Subcategory = c.String(),
                        AssignedTo = c.String(),
                        Requester = c.String(),
                        Escalated = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RequestID);
            
            CreateTable(
                "dbo.CallRequests",
                c => new
                    {
                        CallRequestId = c.Int(nullable: false, identity: true),
                        RequestId = c.Int(nullable: false),
                        PolicyNumber = c.String(nullable: false),
                        ClientName = c.String(nullable: false),
                        ClientContact1 = c.String(nullable: false),
                        ClientContact2 = c.String(),
                        ClientContact3 = c.String(),
                        Consultant = c.String(nullable: false),
                        CallDate = c.String(nullable: false),
                        CallType = c.Int(nullable: false),
                        RiskType = c.Int(nullable: false),
                        RiskDescription = c.String(),
                        CallPart = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CallRequestId)
                .ForeignKey("dbo.Requests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId);
            
            CreateTable(
                "dbo.Remarks",
                c => new
                    {
                        RemarkId = c.Int(nullable: false, identity: true),
                        RequestId = c.Int(nullable: false),
                        RemarkBy = c.String(nullable: false),
                        RemarkDate = c.DateTime(nullable: false),
                        Content = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RemarkId)
                .ForeignKey("dbo.Requests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId);
            
            CreateTable(
                "dbo.RequestLinks",
                c => new
                    {
                        RequestLinkID = c.Int(nullable: false, identity: true),
                        RequestID = c.Int(nullable: false),
                        LinkID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RequestLinkID)
                .ForeignKey("dbo.Requests", t => t.RequestID, cascadeDelete: true)
                .Index(t => t.RequestID);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApplicationRoleGroups",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.GroupId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Manager = c.String(),
                        isActive = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.ApplicationUserGroups",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.GroupId })
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.GroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUserGroups", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationUserGroups", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationRoleGroups", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.ApplicationRoleGroups", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.RequestLinks", "RequestID", "dbo.Requests");
            DropForeignKey("dbo.Remarks", "RequestId", "dbo.Requests");
            DropForeignKey("dbo.EmployeeRequests", "RequestId", "dbo.Requests");
            DropForeignKey("dbo.CallRequests", "RequestId", "dbo.Requests");
            DropForeignKey("dbo.EmployeeRequests", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "BusinessUnitId", "dbo.BusinessUnits");
            DropForeignKey("dbo.BusinessUnitManagements", "BusinessUnitId", "dbo.BusinessUnits");
            DropForeignKey("dbo.BusinessUnitAccesses", "BusinessUnitId", "dbo.BusinessUnits");
            DropIndex("dbo.ApplicationUserGroups", new[] { "GroupId" });
            DropIndex("dbo.ApplicationUserGroups", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "User_Id" });
            DropIndex("dbo.ApplicationRoleGroups", new[] { "GroupId" });
            DropIndex("dbo.ApplicationRoleGroups", new[] { "RoleId" });
            DropIndex("dbo.RequestLinks", new[] { "RequestID" });
            DropIndex("dbo.Remarks", new[] { "RequestId" });
            DropIndex("dbo.CallRequests", new[] { "RequestId" });
            DropIndex("dbo.EmployeeRequests", new[] { "RequestId" });
            DropIndex("dbo.EmployeeRequests", new[] { "EmployeeId" });
            DropIndex("dbo.Employees", new[] { "BusinessUnitId" });
            DropIndex("dbo.BusinessUnitManagements", new[] { "BusinessUnitId" });
            DropIndex("dbo.BusinessUnitAccesses", new[] { "BusinessUnitId" });
            DropTable("dbo.ApplicationUserGroups");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ApplicationRoleGroups");
            DropTable("dbo.Groups");
            DropTable("dbo.RequestLinks");
            DropTable("dbo.Remarks");
            DropTable("dbo.CallRequests");
            DropTable("dbo.Requests");
            DropTable("dbo.EmployeeRequests");
            DropTable("dbo.Employees");
            DropTable("dbo.BusinessUnitManagements");
            DropTable("dbo.BusinessUnitAccesses");
            DropTable("dbo.BusinessUnits");
            DropTable("dbo.BusinessHours");
            DropTable("dbo.AgentDepartments");
        }
    }
}

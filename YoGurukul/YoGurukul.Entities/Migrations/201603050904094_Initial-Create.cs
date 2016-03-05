namespace YoGurukul.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseName = c.String(maxLength: 50),
                        CreatedBy = c.Int(),
                        CrearedOn = c.DateTime(),
                        ModifiedBy = c.Int(),
                        ModifiedOn = c.DateTime(),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(maxLength: 50),
                        CourseId = c.Int(nullable: false),
                        CreatedBy = c.Int(),
                        CrearedOn = c.DateTime(),
                        ModifiedBy = c.Int(),
                        ModifiedOn = c.DateTime(),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.SubjectId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Teacher",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Qualification = c.String(maxLength: 50),
                        Experience = c.String(maxLength: 50),
                        PrimarySubjectId = c.Int(),
                        SecondarySubjectId = c.Int(),
                        Location = c.String(maxLength: 50),
                        Source = c.String(maxLength: 200),
                        Summary = c.String(),
                        AdditionalInfo = c.String(),
                        ImagePath = c.String(),
                        CreatedBy = c.Int(),
                        CrearedOn = c.DateTime(),
                        ModifiedBy = c.Int(),
                        ModifiedOn = c.DateTime(),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.TeacherId)
                .ForeignKey("dbo.Subjects", t => t.PrimarySubjectId)
                .ForeignKey("dbo.Subjects", t => t.SecondarySubjectId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.PrimarySubjectId)
                .Index(t => t.SecondarySubjectId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Password = c.String(maxLength: 50),
                        Gender = c.String(maxLength: 50),
                        EmailAddress = c.String(nullable: false, maxLength: 50),
                        MobileNumber = c.String(maxLength: 50),
                        PersonTypeId = c.Int(),
                        CreatedBy = c.Int(),
                        CrearedOn = c.DateTime(),
                        ModifiedBy = c.Int(),
                        ModifiedOn = c.DateTime(),
                        IsActive = c.Boolean(),
                        RoleId = c.Int(),
                        User1_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Users", t => t.User1_UserId)
                .Index(t => t.User1_UserId);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        SessionId = c.Int(nullable: false, identity: true),
                        SessionTypeId = c.Int(nullable: false),
                        Topic = c.String(maxLength: 100),
                        TimeSlotId = c.Int(nullable: false),
                        TeacherId = c.Int(),
                        StudentId = c.Int(),
                        Date = c.String(maxLength: 50),
                        ActualStartTime = c.String(maxLength: 50),
                        ActualEndTime = c.String(maxLength: 50),
                        StatusId = c.Int(),
                        CreatedBy = c.Int(),
                        CrearedOn = c.DateTime(),
                        ModifiedBy = c.Int(),
                        ModifiedOn = c.DateTime(),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.SessionId)
                .ForeignKey("dbo.SessionStatus", t => t.StatusId)
                .ForeignKey("dbo.SessionTypes", t => t.SessionTypeId, cascadeDelete: true)
                .ForeignKey("dbo.TimeSlots", t => t.TimeSlotId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.StudentId)
                .ForeignKey("dbo.Users", t => t.TeacherId)
                .Index(t => t.SessionTypeId)
                .Index(t => t.TimeSlotId)
                .Index(t => t.TeacherId)
                .Index(t => t.StudentId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.SessionStatus",
                c => new
                    {
                        SessionStatusId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        CreatedBy = c.Int(),
                        CrearedOn = c.DateTime(),
                        ModifiedBy = c.Int(),
                        ModifiedOn = c.DateTime(),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.SessionStatusId);
            
            CreateTable(
                "dbo.SessionTypes",
                c => new
                    {
                        SessionTypeId = c.Int(nullable: false, identity: true),
                        SessionTypeName = c.String(maxLength: 50),
                        CreatedBy = c.Int(),
                        CrearedOn = c.DateTime(),
                        ModifiedBy = c.Int(),
                        ModifiedOn = c.DateTime(),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.SessionTypeId);
            
            CreateTable(
                "dbo.TimeSlots",
                c => new
                    {
                        TimeSlotId = c.Int(nullable: false, identity: true),
                        StartTime = c.String(maxLength: 50),
                        EndTime = c.String(maxLength: 50),
                        Active = c.String(maxLength: 10, fixedLength: true),
                        CreatedBy = c.Int(),
                        CrearedOn = c.DateTime(),
                        ModifiedBy = c.Int(),
                        ModifiedOn = c.DateTime(),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.TimeSlotId);
            
            CreateTable(
                "dbo.DailyAvailabilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GuruId = c.Int(nullable: false),
                        TimeSlotId = c.Int(nullable: false),
                        WeekId = c.Int(nullable: false),
                        CreatedBy = c.Int(),
                        CrearedOn = c.DateTime(),
                        ModifiedBy = c.Int(),
                        ModifiedOn = c.DateTime(),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TimeSlots", t => t.TimeSlotId, cascadeDelete: true)
                .ForeignKey("dbo.Weeks", t => t.WeekId, cascadeDelete: true)
                .Index(t => t.TimeSlotId)
                .Index(t => t.WeekId);
            
            CreateTable(
                "dbo.Weeks",
                c => new
                    {
                        WeekId = c.Int(nullable: false, identity: true),
                        WeekName = c.String(nullable: false, maxLength: 50),
                        CreatedBy = c.Int(),
                        CrearedOn = c.DateTime(),
                        ModifiedBy = c.Int(),
                        ModifiedOn = c.DateTime(),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.WeekId);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Location = c.String(maxLength: 50),
                        Source = c.String(maxLength: 200),
                        Summary = c.String(),
                        AdditionalInfo = c.String(),
                        ImagePath = c.String(),
                        CreatedBy = c.Int(),
                        CrearedOn = c.DateTime(),
                        ModifiedBy = c.Int(),
                        ModifiedOn = c.DateTime(),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Users", t => t.StudentId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        DocumentId = c.Int(nullable: false, identity: true),
                        DocumentTypeId = c.Int(),
                        Data = c.Binary(),
                        GuruId = c.Int(),
                        DocumentName = c.String(maxLength: 50),
                        CreatedBy = c.Int(),
                        CrearedOn = c.DateTime(),
                        ModifiedBy = c.Int(),
                        ModifiedOn = c.DateTime(),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.DocumentId)
                .ForeignKey("dbo.DocumentTypes", t => t.DocumentTypeId)
                .Index(t => t.DocumentTypeId);
            
            CreateTable(
                "dbo.DocumentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DocumentType = c.String(maxLength: 50),
                        CreatedBy = c.Int(),
                        CrearedOn = c.DateTime(),
                        ModifiedBy = c.Int(),
                        ModifiedOn = c.DateTime(),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FeedBacks",
                c => new
                    {
                        FeedbackID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        MobileNumber = c.Int(),
                        Message = c.String(),
                        CreatedBy = c.Int(),
                        CrearedOn = c.DateTime(),
                        ModifiedBy = c.Int(),
                        ModifiedOn = c.DateTime(),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.FeedbackID);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        LanguageId = c.Int(nullable: false, identity: true),
                        LanguageName = c.String(maxLength: 50),
                        CreatedBy = c.Int(),
                        CrearedOn = c.DateTime(),
                        ModifiedBy = c.Int(),
                        ModifiedOn = c.DateTime(),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.LanguageId);
            
            CreateTable(
                "dbo.TeacherLanguage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LanguageId = c.Int(),
                        GuruId = c.Int(nullable: false),
                        CreatedBy = c.Int(),
                        CrearedOn = c.DateTime(),
                        ModifiedBy = c.Int(),
                        ModifiedOn = c.DateTime(),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Languages", t => t.LanguageId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.PersonTypes",
                c => new
                    {
                        PersonTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        CreatedBy = c.Int(),
                        CrearedOn = c.DateTime(),
                        ModifiedBy = c.Int(),
                        ModifiedOn = c.DateTime(),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.PersonTypeId);
            
            CreateTable(
                "dbo.RoleMaster",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(maxLength: 50),
                        CreatedBy = c.Int(),
                        CrearedOn = c.DateTime(),
                        ModifiedBy = c.Int(),
                        ModifiedOn = c.DateTime(),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeacherLanguage", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.Documents", "DocumentTypeId", "dbo.DocumentTypes");
            DropForeignKey("dbo.Teacher", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "User1_UserId", "dbo.Users");
            DropForeignKey("dbo.Student", "StudentId", "dbo.Users");
            DropForeignKey("dbo.Sessions", "TeacherId", "dbo.Users");
            DropForeignKey("dbo.Sessions", "StudentId", "dbo.Users");
            DropForeignKey("dbo.Sessions", "TimeSlotId", "dbo.TimeSlots");
            DropForeignKey("dbo.DailyAvailabilities", "WeekId", "dbo.Weeks");
            DropForeignKey("dbo.DailyAvailabilities", "TimeSlotId", "dbo.TimeSlots");
            DropForeignKey("dbo.Sessions", "SessionTypeId", "dbo.SessionTypes");
            DropForeignKey("dbo.Sessions", "StatusId", "dbo.SessionStatus");
            DropForeignKey("dbo.Teacher", "SecondarySubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Teacher", "PrimarySubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Subjects", "CourseId", "dbo.Courses");
            DropIndex("dbo.TeacherLanguage", new[] { "LanguageId" });
            DropIndex("dbo.Documents", new[] { "DocumentTypeId" });
            DropIndex("dbo.Student", new[] { "StudentId" });
            DropIndex("dbo.DailyAvailabilities", new[] { "WeekId" });
            DropIndex("dbo.DailyAvailabilities", new[] { "TimeSlotId" });
            DropIndex("dbo.Sessions", new[] { "StatusId" });
            DropIndex("dbo.Sessions", new[] { "StudentId" });
            DropIndex("dbo.Sessions", new[] { "TeacherId" });
            DropIndex("dbo.Sessions", new[] { "TimeSlotId" });
            DropIndex("dbo.Sessions", new[] { "SessionTypeId" });
            DropIndex("dbo.Users", new[] { "User1_UserId" });
            DropIndex("dbo.Teacher", new[] { "SecondarySubjectId" });
            DropIndex("dbo.Teacher", new[] { "PrimarySubjectId" });
            DropIndex("dbo.Teacher", new[] { "UserId" });
            DropIndex("dbo.Subjects", new[] { "CourseId" });
            DropTable("dbo.RoleMaster");
            DropTable("dbo.PersonTypes");
            DropTable("dbo.TeacherLanguage");
            DropTable("dbo.Languages");
            DropTable("dbo.FeedBacks");
            DropTable("dbo.DocumentTypes");
            DropTable("dbo.Documents");
            DropTable("dbo.Student");
            DropTable("dbo.Weeks");
            DropTable("dbo.DailyAvailabilities");
            DropTable("dbo.TimeSlots");
            DropTable("dbo.SessionTypes");
            DropTable("dbo.SessionStatus");
            DropTable("dbo.Sessions");
            DropTable("dbo.Users");
            DropTable("dbo.Teacher");
            DropTable("dbo.Subjects");
            DropTable("dbo.Courses");
        }
    }
}

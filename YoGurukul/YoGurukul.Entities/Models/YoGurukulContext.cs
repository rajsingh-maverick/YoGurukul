using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using YoGurukul.Entities.Models.Mapping;

namespace YoGurukul.Entities.Models
{
    public partial class YoGurukulContext : DbContext
    {
        static YoGurukulContext()
        {
            Database.SetInitializer<YoGurukulContext>(null);
        }

        public YoGurukulContext()
            : base("Name=YoGurukulContext")
        {
        }

        public DbSet<Cours> Courses { get; set; }
        public DbSet<DailyAvailability> DailyAvailabilities { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<PersonType> PersonTypes { get; set; }
        public DbSet<RoleMaster> RoleMasters { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<SessionStatu> SessionStatus { get; set; }
        public DbSet<SessionType> SessionTypes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherLanguage> TeacherLanguages { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Week> Weeks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CoursMap());
            modelBuilder.Configurations.Add(new DailyAvailabilityMap());
            modelBuilder.Configurations.Add(new DocumentMap());
            modelBuilder.Configurations.Add(new DocumentTypeMap());
            modelBuilder.Configurations.Add(new FeedBackMap());
            modelBuilder.Configurations.Add(new LanguageMap());
            modelBuilder.Configurations.Add(new PersonTypeMap());
            modelBuilder.Configurations.Add(new RoleMasterMap());
            modelBuilder.Configurations.Add(new SessionMap());
            modelBuilder.Configurations.Add(new SessionStatuMap());
            modelBuilder.Configurations.Add(new SessionTypeMap());
            modelBuilder.Configurations.Add(new StudentMap());
            modelBuilder.Configurations.Add(new SubjectMap());
            modelBuilder.Configurations.Add(new TeacherMap());
            modelBuilder.Configurations.Add(new TeacherLanguageMap());
            modelBuilder.Configurations.Add(new TimeSlotMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new WeekMap());
        }
    }
}

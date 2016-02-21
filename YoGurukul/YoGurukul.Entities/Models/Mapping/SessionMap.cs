using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace YoGurukul.Entities.Models.Mapping
{
    public class SessionMap : EntityTypeConfiguration<Session>
    {
        public SessionMap()
        {
            // Primary Key
            this.HasKey(t => t.SessionId);

            // Properties
            this.Property(t => t.Topic)
                .HasMaxLength(100);

            this.Property(t => t.Date)
                .HasMaxLength(50);

            this.Property(t => t.ActualStartTime)
                .HasMaxLength(50);

            this.Property(t => t.ActualEndTime)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Sessions");
            this.Property(t => t.SessionId).HasColumnName("SessionId");
            this.Property(t => t.SessionTypeId).HasColumnName("SessionTypeId");
            this.Property(t => t.Topic).HasColumnName("Topic");
            this.Property(t => t.TimeSlotId).HasColumnName("TimeSlotId");
            this.Property(t => t.TeacherId).HasColumnName("TeacherId");
            this.Property(t => t.StudentId).HasColumnName("StudentId");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.ActualStartTime).HasColumnName("ActualStartTime");
            this.Property(t => t.ActualEndTime).HasColumnName("ActualEndTime");
            this.Property(t => t.StatusId).HasColumnName("StatusId");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CrearedOn).HasColumnName("CrearedOn");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");
            this.Property(t => t.IsActive).HasColumnName("IsActive");

            // Relationships
            this.HasRequired(t => t.SessionType)
                .WithMany(t => t.Sessions)
                .HasForeignKey(d => d.SessionTypeId);
            this.HasOptional(t => t.SessionStatu)
                .WithMany(t => t.Sessions)
                .HasForeignKey(d => d.StatusId);
            this.HasOptional(t => t.User)
                .WithMany(t => t.Sessions)
                .HasForeignKey(d => d.StudentId);
            this.HasOptional(t => t.User1)
                .WithMany(t => t.Sessions1)
                .HasForeignKey(d => d.TeacherId);
            this.HasRequired(t => t.TimeSlot)
                .WithMany(t => t.Sessions)
                .HasForeignKey(d => d.TimeSlotId);

        }
    }
}

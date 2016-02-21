using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace YoGurukul.Entities.Models.Mapping
{
    public class TeacherMap : EntityTypeConfiguration<Teacher>
    {
        public TeacherMap()
        {
            // Primary Key
            this.HasKey(t => t.TeacherId);

            // Properties
            this.Property(t => t.Qualification)
                .HasMaxLength(50);

            this.Property(t => t.Experience)
                .HasMaxLength(50);

            this.Property(t => t.Location)
                .HasMaxLength(50);

            this.Property(t => t.Source)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Teacher");
            this.Property(t => t.TeacherId).HasColumnName("TeacherId");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.Qualification).HasColumnName("Qualification");
            this.Property(t => t.Experience).HasColumnName("Experience");
            this.Property(t => t.PrimarySubjectId).HasColumnName("PrimarySubjectId");
            this.Property(t => t.SecondarySubjectId).HasColumnName("SecondarySubjectId");
            this.Property(t => t.Location).HasColumnName("Location");
            this.Property(t => t.Source).HasColumnName("Source");
            this.Property(t => t.Summary).HasColumnName("Summary");
            this.Property(t => t.AdditionalInfo).HasColumnName("AdditionalInfo");
            this.Property(t => t.ImagePath).HasColumnName("ImagePath");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CrearedOn).HasColumnName("CrearedOn");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");
            this.Property(t => t.IsActive).HasColumnName("IsActive");

            // Relationships
            this.HasOptional(t => t.Subject)
                .WithMany(t => t.Teachers)
                .HasForeignKey(d => d.PrimarySubjectId);
            this.HasOptional(t => t.Subject1)
                .WithMany(t => t.Teachers1)
                .HasForeignKey(d => d.SecondarySubjectId);
            this.HasRequired(t => t.User)
                .WithMany(t => t.Teachers)
                .HasForeignKey(d => d.UserId);

        }
    }
}

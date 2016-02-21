using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace YoGurukul.Entities.Models.Mapping
{
    public class StudentMap : EntityTypeConfiguration<Student>
    {
        public StudentMap()
        {
            // Primary Key
            this.HasKey(t => t.StudentId);

            // Properties
            this.Property(t => t.Location)
                .HasMaxLength(50);

            this.Property(t => t.Source)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Student");
            this.Property(t => t.StudentId).HasColumnName("StudentId");
            this.Property(t => t.UserId).HasColumnName("UserId");
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
            this.HasRequired(t => t.User)
                .WithOptional(t => t.Student);

        }
    }
}

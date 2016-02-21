using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace YoGurukul.Entities.Models.Mapping
{
    public class SubjectMap : EntityTypeConfiguration<Subject>
    {
        public SubjectMap()
        {
            // Primary Key
            this.HasKey(t => t.SubjectId);

            // Properties
            this.Property(t => t.SubjectName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Subjects");
            this.Property(t => t.SubjectId).HasColumnName("SubjectId");
            this.Property(t => t.SubjectName).HasColumnName("SubjectName");
            this.Property(t => t.CourseId).HasColumnName("CourseId");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CrearedOn).HasColumnName("CrearedOn");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");
            this.Property(t => t.IsActive).HasColumnName("IsActive");

            // Relationships
            this.HasRequired(t => t.Cours)
                .WithMany(t => t.Subjects)
                .HasForeignKey(d => d.CourseId);

        }
    }
}

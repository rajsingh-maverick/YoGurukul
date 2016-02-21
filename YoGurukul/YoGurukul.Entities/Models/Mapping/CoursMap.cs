using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace YoGurukul.Entities.Models.Mapping
{
    public class CoursMap : EntityTypeConfiguration<Cours>
    {
        public CoursMap()
        {
            // Primary Key
            this.HasKey(t => t.CourseId);

            // Properties
            this.Property(t => t.CourseName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Courses");
            this.Property(t => t.CourseId).HasColumnName("CourseId");
            this.Property(t => t.CourseName).HasColumnName("CourseName");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CrearedOn).HasColumnName("CrearedOn");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
        }
    }
}

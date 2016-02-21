using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace YoGurukul.Entities.Models.Mapping
{
    public class TeacherLanguageMap : EntityTypeConfiguration<TeacherLanguage>
    {
        public TeacherLanguageMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("TeacherLanguage");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.LanguageId).HasColumnName("LanguageId");
            this.Property(t => t.GuruId).HasColumnName("GuruId");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CrearedOn).HasColumnName("CrearedOn");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");
            this.Property(t => t.IsActive).HasColumnName("IsActive");

            // Relationships
            this.HasOptional(t => t.Language)
                .WithMany(t => t.TeacherLanguages)
                .HasForeignKey(d => d.LanguageId);

        }
    }
}

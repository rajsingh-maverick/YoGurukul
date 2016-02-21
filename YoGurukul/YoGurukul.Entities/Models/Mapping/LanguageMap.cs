using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace YoGurukul.Entities.Models.Mapping
{
    public class LanguageMap : EntityTypeConfiguration<Language>
    {
        public LanguageMap()
        {
            // Primary Key
            this.HasKey(t => t.LanguageId);

            // Properties
            this.Property(t => t.LanguageName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Languages");
            this.Property(t => t.LanguageId).HasColumnName("LanguageId");
            this.Property(t => t.LanguageName).HasColumnName("LanguageName");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CrearedOn).HasColumnName("CrearedOn");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
        }
    }
}

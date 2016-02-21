using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace YoGurukul.Entities.Models.Mapping
{
    public class DocumentTypeMap : EntityTypeConfiguration<DocumentType>
    {
        public DocumentTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.DocumentType1)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("DocumentTypes");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.DocumentType1).HasColumnName("DocumentType");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CrearedOn).HasColumnName("CrearedOn");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
        }
    }
}

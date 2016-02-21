using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace YoGurukul.Entities.Models.Mapping
{
    public class DocumentMap : EntityTypeConfiguration<Document>
    {
        public DocumentMap()
        {
            // Primary Key
            this.HasKey(t => t.DocumentId);

            // Properties
            this.Property(t => t.DocumentName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Documents");
            this.Property(t => t.DocumentId).HasColumnName("DocumentId");
            this.Property(t => t.DocumentTypeId).HasColumnName("DocumentTypeId");
            this.Property(t => t.Data).HasColumnName("Data");
            this.Property(t => t.GuruId).HasColumnName("GuruId");
            this.Property(t => t.DocumentName).HasColumnName("DocumentName");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CrearedOn).HasColumnName("CrearedOn");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");
            this.Property(t => t.IsActive).HasColumnName("IsActive");

            // Relationships
            this.HasOptional(t => t.DocumentType)
                .WithMany(t => t.Documents)
                .HasForeignKey(d => d.DocumentTypeId);

        }
    }
}

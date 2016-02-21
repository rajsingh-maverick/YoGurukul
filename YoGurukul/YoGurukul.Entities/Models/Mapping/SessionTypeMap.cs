using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace YoGurukul.Entities.Models.Mapping
{
    public class SessionTypeMap : EntityTypeConfiguration<SessionType>
    {
        public SessionTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.SessionTypeId);

            // Properties
            this.Property(t => t.SessionTypeName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("SessionTypes");
            this.Property(t => t.SessionTypeId).HasColumnName("SessionTypeId");
            this.Property(t => t.SessionTypeName).HasColumnName("SessionTypeName");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CrearedOn).HasColumnName("CrearedOn");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
        }
    }
}

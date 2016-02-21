using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace YoGurukul.Entities.Models.Mapping
{
    public class SessionStatuMap : EntityTypeConfiguration<SessionStatu>
    {
        public SessionStatuMap()
        {
            // Primary Key
            this.HasKey(t => t.SessionStatusId);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("SessionStatus");
            this.Property(t => t.SessionStatusId).HasColumnName("SessionStatusId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CrearedOn).HasColumnName("CrearedOn");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace YoGurukul.Entities.Models.Mapping
{
    public class WeekMap : EntityTypeConfiguration<Week>
    {
        public WeekMap()
        {
            // Primary Key
            this.HasKey(t => t.WeekId);

            // Properties
            this.Property(t => t.WeekName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Weeks");
            this.Property(t => t.WeekId).HasColumnName("WeekId");
            this.Property(t => t.WeekName).HasColumnName("WeekName");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CrearedOn).HasColumnName("CrearedOn");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace YoGurukul.Entities.Models.Mapping
{
    public class TimeSlotMap : EntityTypeConfiguration<TimeSlot>
    {
        public TimeSlotMap()
        {
            // Primary Key
            this.HasKey(t => t.TimeSlotId);

            // Properties
            this.Property(t => t.StartTime)
                .HasMaxLength(50);

            this.Property(t => t.EndTime)
                .HasMaxLength(50);

            this.Property(t => t.Active)
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("TimeSlots");
            this.Property(t => t.TimeSlotId).HasColumnName("TimeSlotId");
            this.Property(t => t.StartTime).HasColumnName("StartTime");
            this.Property(t => t.EndTime).HasColumnName("EndTime");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CrearedOn).HasColumnName("CrearedOn");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
        }
    }
}

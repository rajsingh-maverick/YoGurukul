using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace YoGurukul.Entities.Models.Mapping
{
    public class DailyAvailabilityMap : EntityTypeConfiguration<DailyAvailability>
    {
        public DailyAvailabilityMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("DailyAvailabilities");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.GuruId).HasColumnName("GuruId");
            this.Property(t => t.TimeSlotId).HasColumnName("TimeSlotId");
            this.Property(t => t.WeekId).HasColumnName("WeekId");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CrearedOn).HasColumnName("CrearedOn");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");
            this.Property(t => t.IsActive).HasColumnName("IsActive");

            // Relationships
            this.HasRequired(t => t.TimeSlot)
                .WithMany(t => t.DailyAvailabilities)
                .HasForeignKey(d => d.TimeSlotId);
            this.HasRequired(t => t.Week)
                .WithMany(t => t.DailyAvailabilities)
                .HasForeignKey(d => d.WeekId);

        }
    }
}

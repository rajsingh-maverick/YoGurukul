using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace YoGurukul.Entities.Models.Mapping
{
    public class FeedBackMap : EntityTypeConfiguration<FeedBack>
    {
        public FeedBackMap()
        {
            // Primary Key
            this.HasKey(t => t.FeedbackID);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("FeedBacks");
            this.Property(t => t.FeedbackID).HasColumnName("FeedbackID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.MobileNumber).HasColumnName("MobileNumber");
            this.Property(t => t.Message).HasColumnName("Message");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CrearedOn).HasColumnName("CrearedOn");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
        }
    }
}

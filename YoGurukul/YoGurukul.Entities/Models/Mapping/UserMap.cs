using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace YoGurukul.Entities.Models.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.UserId);

            // Properties
            this.Property(t => t.FirstName)
                .HasMaxLength(50);

            this.Property(t => t.LastName)
                .HasMaxLength(50);

            this.Property(t => t.Password)
                .HasMaxLength(50);

            this.Property(t => t.Gender)
                .HasMaxLength(50);

            this.Property(t => t.EmailAddress)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.MobileNumber)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Users");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.Gender).HasColumnName("Gender");
            this.Property(t => t.EmailAddress).HasColumnName("EmailAddress");
            this.Property(t => t.MobileNumber).HasColumnName("MobileNumber");
            this.Property(t => t.PersonTypeId).HasColumnName("PersonTypeId");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CrearedOn).HasColumnName("CrearedOn");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.RoleId).HasColumnName("RoleId");

            // Relationships
            this.HasRequired(t => t.User1)
                .WithOptional(t => t.Users1);

        }
    }
}

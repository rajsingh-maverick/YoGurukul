using System;
using System.Collections.Generic;

namespace YoGurukul.Entities.Models
{
    public partial class User
    {
        public User()
        {
            this.Sessions = new List<Session>();
            this.Sessions1 = new List<Session>();
            this.Teachers = new List<Teacher>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public Nullable<int> PersonTypeId { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CrearedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> RoleId { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
        public virtual ICollection<Session> Sessions1 { get; set; }
        public virtual Student Student { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
        public virtual User Users1 { get; set; }
        public virtual User User1 { get; set; }
    }
}

using System.Collections.Generic;

namespace YoGurukul.DataContract
{
    public partial class UserDco : AuditableEntity
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public int PersonTypeId { get; set; }

        public virtual ICollection<GuruProfileDco> GuruProfiles { get; set; }
        public virtual ICollection<SessionDco> Sessions { get; set; }
        public virtual ICollection<SessionDco> Sessions1 { get; set; }

    }
}

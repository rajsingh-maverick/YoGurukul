using System;
using System.Collections.Generic;

namespace YoGurukul.Entities.Models
{
    public partial class SessionType
    {
        public SessionType()
        {
            this.Sessions = new List<Session>();
        }

        public int SessionTypeId { get; set; }
        public string SessionTypeName { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CrearedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
    }
}

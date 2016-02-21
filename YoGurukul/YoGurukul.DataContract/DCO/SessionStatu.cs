using System.Collections.Generic;

namespace YoGurukul.DataContract
{
    public class SessionStatusDco:AuditableEntity
    {
         
        public int SessionStatusId { get; set; }
        public string Name { get; set; }
         
        public virtual ICollection<SessionDco> Sessions { get; set; }
    }
}

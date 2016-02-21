using System.Collections.Generic;

namespace YoGurukul.DataContract
{
    public partial class SessionTypeDco : AuditableEntity
    {

        public int SessionTypeId { get; set; }
        public string SessionTypeName { get; set; }

        public virtual ICollection<SessionDco> Sessions { get; set; }
    }
}

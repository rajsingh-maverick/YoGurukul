using System.Collections.Generic;

namespace YoGurukul.DataContract
{
    public partial class TimeSlotDco : AuditableEntity
    {

        public int TimeSlotId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Active { get; set; }

        public virtual ICollection<DailyAvailabilityDco> DailyAvailabilities { get; set; }
        public virtual ICollection<SessionDco> Sessions { get; set; }
    }
}

using System.Collections.Generic;

namespace YoGurukul.DataContract
{
    public partial class WeekDco:AuditableEntity
    {
         
        public int WeekId { get; set; }
        public string WeekName { get; set; }
         
        public virtual ICollection<DailyAvailabilityDco> DailyAvailabilities { get; set; }
    }
}

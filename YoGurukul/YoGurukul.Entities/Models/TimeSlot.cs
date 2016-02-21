using System;
using System.Collections.Generic;

namespace YoGurukul.Entities.Models
{
    public partial class TimeSlot
    {
        public TimeSlot()
        {
            this.DailyAvailabilities = new List<DailyAvailability>();
            this.Sessions = new List<Session>();
        }

        public int TimeSlotId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Active { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CrearedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public virtual ICollection<DailyAvailability> DailyAvailabilities { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
    }
}

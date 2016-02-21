using System;
using System.Collections.Generic;

namespace YoGurukul.Entities.Models
{
    public partial class DailyAvailability
    {
        public int Id { get; set; }
        public int GuruId { get; set; }
        public int TimeSlotId { get; set; }
        public int WeekId { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CrearedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public virtual TimeSlot TimeSlot { get; set; }
        public virtual Week Week { get; set; }
    }
}

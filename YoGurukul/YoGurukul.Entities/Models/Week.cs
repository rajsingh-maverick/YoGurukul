using System;
using System.Collections.Generic;

namespace YoGurukul.Entities.Models
{
    public partial class Week
    {
        public Week()
        {
            this.DailyAvailabilities = new List<DailyAvailability>();
        }

        public int WeekId { get; set; }
        public string WeekName { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CrearedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public virtual ICollection<DailyAvailability> DailyAvailabilities { get; set; }
    }
}

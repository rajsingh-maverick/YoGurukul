using System;
using System.Collections.Generic;

namespace YoGurukul.Entities.Models
{
    public partial class Session
    {
        public int SessionId { get; set; }
        public int SessionTypeId { get; set; }
        public string Topic { get; set; }
        public int TimeSlotId { get; set; }
        public Nullable<int> TeacherId { get; set; }
        public Nullable<int> StudentId { get; set; }
        public string Date { get; set; }
        public string ActualStartTime { get; set; }
        public string ActualEndTime { get; set; }
        public Nullable<int> StatusId { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CrearedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public virtual SessionType SessionType { get; set; }
        public virtual SessionStatu SessionStatu { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
        public virtual TimeSlot TimeSlot { get; set; }
    }
}

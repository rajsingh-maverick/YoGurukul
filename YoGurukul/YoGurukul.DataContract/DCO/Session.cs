using System.Collections.Generic;

namespace YoGurukul.DataContract
{
    public partial class SessionDco : AuditableEntity
    {
        public int SessionId { get; set; }
        public int SessionTypeId { get; set; }
        public string Topic { get; set; }
        public int TimeSlotId { get; set; }
        public int TeacherId { get; set; }
        public int StudentId { get; set; }
        public string Date { get; set; }
        public string ActualStartTime { get; set; }
        public string ActualEndTime { get; set; }
        public int StatusId { get; set; }
        public virtual SessionTypeDco SessionType { get; set; }
        public virtual SessionStatusDco SessionStatus { get; set; }
        public virtual UserDco User { get; set; }
        public virtual TimeSlotDco TimeSlot { get; set; }
    }
}

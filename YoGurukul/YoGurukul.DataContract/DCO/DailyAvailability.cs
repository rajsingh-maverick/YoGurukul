namespace YoGurukul.DataContract
{
    public class DailyAvailabilityDco:AuditableEntity 
    {
        public int Id { get; set; }
        public int GuruId { get; set; }
        public int TimeSlotId { get; set; }
        public int WeekId { get; set; } 
        public virtual TimeSlotDco TimeSlot { get; set; }
        public virtual WeekDco Week { get; set; }
    }
}

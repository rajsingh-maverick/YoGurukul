using System.Collections.Generic;

namespace YoGurukul.DataContract
{
    public class FeedBackDco : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MobileNumber { get; set; }
        public string Message { get; set; }

    }
}

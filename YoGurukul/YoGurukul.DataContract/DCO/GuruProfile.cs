using System.Collections.Generic;

namespace YoGurukul.DataContract
{
    public class GuruProfileDco:AuditableEntity 
    {
        public int GuruId { get; set; }
        public int UserId { get; set; }
        public string Qualification { get; set; }
        public string Experience { get; set; }
        public int PrimarySubjectId { get; set; }
        public int  SecondarySubjectId { get; set; }
        public string Location { get; set; }
        public string Source { get; set; }
        public string Summary { get; set; }
        public string AdditionalInfo { get; set; }
        public string ImagePath { get; set; } 
        public virtual SubjectDco Subject { get; set; }   
        public virtual UserDco User { get; set; }
    }
}

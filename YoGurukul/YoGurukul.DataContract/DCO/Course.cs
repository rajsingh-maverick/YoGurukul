using System.Collections.Generic;
 
namespace YoGurukul.DataContract
{
    public class CourseDco: AuditableEntity
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        
        public virtual ICollection<CourseDco> Subjects { get; set; }
    }
}

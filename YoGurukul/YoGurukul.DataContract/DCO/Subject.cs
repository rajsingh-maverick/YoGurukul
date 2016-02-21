using System.Collections.Generic;

namespace YoGurukul.DataContract
{
    public partial class SubjectDco : AuditableEntity
    {

        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int CourseId { get; set; }

        public virtual CourseDco Course { get; set; }
        public virtual ICollection<GuruProfileDco> GuruProfiles { get; set; }

    }
}

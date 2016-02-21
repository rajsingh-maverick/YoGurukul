using System;
using System.Collections.Generic;

namespace YoGurukul.Entities.Models
{
    public partial class Subject
    {
        public Subject()
        {
            this.Teachers = new List<Teacher>();
            this.Teachers1 = new List<Teacher>();
        }

        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int CourseId { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CrearedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public virtual Cours Cours { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
        public virtual ICollection<Teacher> Teachers1 { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace YoGurukul.Entities.Models
{
    public partial class Cours
    {
        public Cours()
        {
            this.Subjects = new List<Subject>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CrearedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}

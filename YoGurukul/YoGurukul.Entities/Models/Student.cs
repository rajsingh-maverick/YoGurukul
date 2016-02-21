using System;
using System.Collections.Generic;

namespace YoGurukul.Entities.Models
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public int UserId { get; set; }
        public string Location { get; set; }
        public string Source { get; set; }
        public string Summary { get; set; }
        public string AdditionalInfo { get; set; }
        public string ImagePath { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CrearedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public virtual User User { get; set; }
    }
}

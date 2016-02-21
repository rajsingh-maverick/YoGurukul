using System;
using System.Collections.Generic;

namespace YoGurukul.Entities.Models
{
    public partial class TeacherLanguage
    {
        public int Id { get; set; }
        public Nullable<int> LanguageId { get; set; }
        public int GuruId { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CrearedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public virtual Language Language { get; set; }
    }
}

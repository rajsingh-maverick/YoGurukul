using System;
using System.Collections.Generic;

namespace YoGurukul.Entities.Models
{
    public partial class Language
    {
        public Language()
        {
            this.TeacherLanguages = new List<TeacherLanguage>();
        }

        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CrearedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public virtual ICollection<TeacherLanguage> TeacherLanguages { get; set; }
    }
}

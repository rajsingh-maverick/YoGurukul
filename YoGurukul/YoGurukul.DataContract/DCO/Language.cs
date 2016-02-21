using System.Collections.Generic;

namespace YoGurukul.DataContract

{
    public class LanguageDco:AuditableEntity 
    {
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public virtual ICollection<GuruLanguageDco> GuruLanguages { get; set; }
    }
}

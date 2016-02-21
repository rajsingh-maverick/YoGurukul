using System.Collections.Generic;

namespace YoGurukul.DataContract
{
    public class GuruLanguageDco : AuditableEntity
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public int GuruId { get; set; }

        public virtual LanguageDco Language { get; set; }
    }
}

using System.Collections.Generic;

namespace YoGurukul.DataContract
{
    public class DocumentTypeDco:AuditableEntity 
    {
         
        public int Id { get; set; }
        public string DocumentType1 { get; set; } 
        public virtual ICollection<DocumentDco> Documents { get; set; }
    }
}

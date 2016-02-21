using System;
using System.Collections.Generic;

namespace YoGurukul.Entities.Models
{
    public partial class DocumentType
    {
        public DocumentType()
        {
            this.Documents = new List<Document>();
        }

        public int Id { get; set; }
        public string DocumentType1 { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CrearedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
    }
}

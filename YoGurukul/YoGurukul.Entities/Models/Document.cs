using System;
using System.Collections.Generic;

namespace YoGurukul.Entities.Models
{
    public partial class Document
    {
        public int DocumentId { get; set; }
        public Nullable<int> DocumentTypeId { get; set; }
        public byte[] Data { get; set; }
        public Nullable<int> GuruId { get; set; }
        public string DocumentName { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CrearedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public virtual DocumentType DocumentType { get; set; }
    }
}

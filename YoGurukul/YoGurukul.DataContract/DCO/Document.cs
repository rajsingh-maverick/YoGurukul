namespace YoGurukul.DataContract
{
    public partial class DocumentDco : AuditableEntity
    {
        public int DocumentId { get; set; }
        public int DocumentTypeId { get; set; }
        public byte[] Data { get; set; }
        public int GuruId { get; set; }
        public string DocumentName { get; set; }
        public virtual DocumentTypeDco DocumentType { get; set; }
    }
}

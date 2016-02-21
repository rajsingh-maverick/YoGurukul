using System.Collections.Generic;

namespace YoGurukul.DataContract
{
    public partial class PersonTypeDco : AuditableEntity
    {
        public int PersonTypeId { get; set; }
        public string Name { get; set; }
    }
}

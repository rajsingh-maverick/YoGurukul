using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace YoGurukul.DataContract
{

    public abstract class AuditableEntity
    {
         
        public DateTime CreatedOn { get; set; }        
         
        public int CreatedBy { get; set; }
         
        public DateTime ModifiedOn{ get; set; }         
         
        public int ModifiedBy { get; set; }

        public bool  IsActive { get; set; }

    }
}

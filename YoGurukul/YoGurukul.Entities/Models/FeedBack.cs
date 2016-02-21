using System;
using System.Collections.Generic;

namespace YoGurukul.Entities.Models
{
    public partial class FeedBack
    {
        public int FeedbackID { get; set; }
        public string Name { get; set; }
        public Nullable<int> MobileNumber { get; set; }
        public string Message { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CrearedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}

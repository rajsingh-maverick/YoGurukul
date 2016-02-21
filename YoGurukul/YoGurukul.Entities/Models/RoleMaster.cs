using System;
using System.Collections.Generic;

namespace YoGurukul.Entities.Models
{
    public partial class RoleMaster
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CrearedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}

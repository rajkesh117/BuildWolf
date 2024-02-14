using System;
using System.Collections.Generic;
using System.Text;

namespace BuildWolf.Modules.MasterModules
{
    public class categories
    {
        public string CategoryId { get; set; }
        public string LocationId { get; set; }
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}

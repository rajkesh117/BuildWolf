using System;
using System.Collections.Generic;
using System.Text;

namespace BuildWolf.Modules.MasterModules
{
    public class locations
    {
        public string LocationId { get; set; }
        public string LocationName { get; set; }
        public string StateName { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}

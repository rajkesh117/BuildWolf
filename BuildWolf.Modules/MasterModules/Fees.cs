using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace BuildWolf.Modules.MasterModules
{
    public class Fees
    {
        public string FeeId { get; set; }
        public string LocationId { get; set; }
        public string CategoryId { get; set; }
        public Int64 MinFee { get; set; }
        public Int64 MaxFee { get; set; }
        public string Parameter { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
    }
}

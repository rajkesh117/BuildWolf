using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace BuildWolf.Modules.MasterModules
{
    public class Fees : BaseModel
    {
        public string FeeId { get; set; }
        public string LocationId { get; set; }
        public string CategoryId { get; set; }
        public Int64 MinFee { get; set; }
        public Int64 MaxFee { get; set; }
        public string Parameter { get; set; }
    }
}

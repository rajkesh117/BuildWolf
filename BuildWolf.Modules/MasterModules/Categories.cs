using System;
using System.Collections.Generic;
using System.Text;

namespace BuildWolf.Modules.MasterModules
{
    public class categories : BaseModel
    {
        public string CategoryId { get; set; }
        public string LocationId { get; set; }
        public string CategoryName { get; set; }
    }
}

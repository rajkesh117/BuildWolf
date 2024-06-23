using System;
using System.Collections.Generic;
using System.Text;

namespace BuildWolf.Modules.MasterModules
{
    public class UserLocation : BaseModel
    {
        public string? _Id { get; set; }
        public string? UserId { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
    }
}

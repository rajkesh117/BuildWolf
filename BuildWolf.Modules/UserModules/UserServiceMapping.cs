using System;
using System.Collections.Generic;
using System.Text;

namespace BuildWolf.Modules.UserModules
{
    public class UserServiceMapping : BaseModel
    {
        public string UserServiceMappingId { get; set; }
        public string UserId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
    }
}

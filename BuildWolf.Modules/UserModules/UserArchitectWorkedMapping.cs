using System;
using System.Collections.Generic;
using System.Text;

namespace BuildWolf.Modules.UserModules
{
    public class UserArchitectWorkedMapping : BaseModel
    {
        public string? UserArchitectWorkedMappingId { get; set; }
        public string? UserId { get; set; }
        public string ArchitectId { get; set; }
        public string ArchitectName { get; set; }
    }
}

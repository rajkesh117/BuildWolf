using System;
using System.Collections.Generic;
using System.Text;

namespace BuildWolf.Modules.UserModules
{
    public class UserProjectMapping : BaseModel
    {
        public string UserProjectMappingId { get; set; }
        public string UserId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectContent { get; set; }
        public string ProjectDescription { get; set; }
    }
}

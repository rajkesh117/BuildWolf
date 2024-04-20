using System;
using System.Collections.Generic;
using System.Text;

namespace BuildWolf.Modules.UserModules
{
    public class UserReviewMapping : BaseModel
    {
        public string UserReviewMappingId { get; set; }
        public string UserId { get; set; }
        public string Review { get; set; }
    }
}

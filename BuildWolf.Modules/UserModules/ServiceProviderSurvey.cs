using System;
using System.Collections.Generic;
using System.Text;

namespace BuildWolf.Modules.UserModules
{
    public class ServiceProviderSurvey : Users
    {
        public List<UserServiceMapping> ServiceOffered { get; set; }
        public List<UserProjectMapping> Projects { get; set; }
        public List<UserReviewMapping> RatingAndReviews { get; set; }
        public List<UserArchitectWorkedMapping> ArchitectsWorkedWith { get; set; }

    }
}

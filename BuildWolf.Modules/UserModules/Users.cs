using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;

namespace BuildWolf.Modules.UserModules
{
    public class Users : BaseModel
    {
        public string? UserId { get; set; }
        public string UserName { get; set; }
        public string BusinessName { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNo { get; set; }
        public string WebsiteUrl { get; set; }
        public int UserTypeId { get; set; }
        public string ChargesType { get; set; }
        public string Charges { get; set; }
        public string Experience { get; set; }
        public string? Occupation { get; set; }
        public int? Rating { get; set; }
        public string? LocationId { get; set; }

        public List<UserCustomer> ? UserCustomer { get; set; }

    }

    public class UserCustomer : BaseModel
    {
        public string UserCustomerMappingId { get; set; }
        public string UserId { get; set; }
        public string CustomerName { get; set; }
        public string ContactNo { get; set; }
    }
}
